using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        decimal GetProductCurrentPrice(int id);

        List<decimal> GetProductOldPrices(int id);

    }
}
