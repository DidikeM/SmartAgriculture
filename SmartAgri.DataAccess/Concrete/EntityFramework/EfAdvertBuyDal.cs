using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class EfAdvertBuyDal : EfEntityRepositoryBase<AdvertBuy, SmartAgriContext>, IAdvertBuyDal
    {
        private readonly IDbContextFactory<SmartAgriContext> _contextFactory;
        public EfAdvertBuyDal(IDbContextFactory<SmartAgriContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public AdvertBuy GetWithUser(Expression<Func<AdvertBuy, bool>>? filter)
        {
            using var context = _contextFactory.CreateDbContext();
            return filter == null ? context.AdvertBuys.Include(a => a.User).FirstOrDefault()! : context.AdvertBuys.Include(a => a.User).FirstOrDefault(filter)!;
        }

        public List<AdvertBuy> GetAllWithProduct(Expression<Func<AdvertBuy, bool>>? filter)
        {
            using var context = _contextFactory.CreateDbContext();
            return filter == null ? context.AdvertBuys.Include(a => a.Product).ToList()! : context.AdvertBuys.Include(a => a.Product).Where(filter).ToList()!;
        }

        public List<AdvertBuy> GetAllRecent(int count, Expression<Func<AdvertBuy, bool>>? filter = null)
        {
            using var context = _contextFactory.CreateDbContext();
            var adverts = context.AdvertBuys.Include(a => a.Product).Include(a => a.User).AsQueryable();

            if (filter != null)
            {
                adverts = adverts.Where(filter);
            }

            return adverts.OrderBy(a => a.CreatedAt).Take(count).ToList();
        }

    }
}
