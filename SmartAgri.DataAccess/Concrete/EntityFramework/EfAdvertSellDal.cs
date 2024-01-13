using Microsoft.EntityFrameworkCore;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.DataAccess.Concrete.EntityFramework
{
    public class EfAdvertSellDal : EfEntityRepositoryBase<AdvertSell, SmartAgriContext>, IAdvertSellDal
    {
        private readonly IDbContextFactory<SmartAgriContext> _contextFactory;
        public EfAdvertSellDal(IDbContextFactory<SmartAgriContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public AdvertSell GetWithUser(Expression<Func<AdvertSell, bool>>? filter)
        {
            using var context = _contextFactory.CreateDbContext();
            return filter == null ? context.AdvertSells.Include(a => a.User).FirstOrDefault()! : context.AdvertSells.Include(a => a.User).FirstOrDefault(filter)!;
        }

        public List<AdvertSell> GetAllWithProduct(Expression<Func<AdvertSell, bool>>? filter)
        {
            using var context = _contextFactory.CreateDbContext();
            return filter == null ? context.AdvertSells.Include(a => a.Product).ToList()! : context.AdvertSells.Include(a => a.Product).Where(filter).ToList()!;
        }

        public List<AdvertSell> GetAllRecent(int count, Expression<Func<AdvertSell, bool>>? filter = null)
        {
            using var context = _contextFactory.CreateDbContext();
            var adverts = context.AdvertSells.Include(a => a.Product).Include(a => a.User).AsQueryable();

            if (filter != null)
            {
                adverts = adverts.Where(filter);
            }

            return adverts.OrderBy(a => a.CreatedAt).Take(count).ToList();
        }
    }
}
