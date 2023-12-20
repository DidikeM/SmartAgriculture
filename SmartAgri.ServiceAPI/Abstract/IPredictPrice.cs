using SmartAgri.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.ServiceAPI.Abstract
{
    public interface IPredictPrice
    {
        Task<decimal> Predict(ProductEnum product);
    }
}
