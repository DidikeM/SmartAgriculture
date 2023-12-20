using Microsoft.EntityFrameworkCore;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.DataAccess.Concrete.EntityFramework
{
    public class EfAdvertBuyDal : EfEntityRepositoryBase<AdvertBuy, SmartAgriContext>, IAdvertBuyDal
    {
        public EfAdvertBuyDal(IDbContextFactory<SmartAgriContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
