using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.DataAccess.Abstract
{
    public interface IAdvertBuyDal : IEntityRepository<AdvertBuy>
    {
        AdvertBuy GetWithUser(Expression<Func<AdvertBuy, bool>>? filter);
        List<AdvertBuy> GetAllWithProduct(Expression<Func<AdvertBuy, bool>>? filter);
    }
}
