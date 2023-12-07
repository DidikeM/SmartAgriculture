using Microsoft.EntityFrameworkCore;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Concrete;
using SmartAgri.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, SmartAgriContext>, IProductDal
    {
        private readonly IDbContextFactory<SmartAgriContext> _contextFactory;
        public EfProductDal(IDbContextFactory<SmartAgriContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public decimal GetProductCurrentPrice(int id)
        {
            using(var context = _contextFactory.CreateDbContext())
            {
                var result = context.AdvertSells
                    .Where(x => x.ProductId == id && x.StatusId == (int)AdvertStatusEnum.Active)
                    .OrderByDescending(x => x.UnitPrice)
                    .FirstOrDefault();
                return result == null ? -1 : result.UnitPrice;
            }
        }
    }
}
