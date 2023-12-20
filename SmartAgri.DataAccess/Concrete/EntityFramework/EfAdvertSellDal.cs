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
    public class EfAdvertSellDal : EfEntityRepositoryBase<AdvertSell, SmartAgriContext>, IAdvertSellDal
    {
        public EfAdvertSellDal(IDbContextFactory<SmartAgriContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
