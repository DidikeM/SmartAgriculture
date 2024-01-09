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
    public class EfTransactionDal : EfEntityRepositoryBase<Transaction, SmartAgriContext>, ITransactionDal
    {
        public EfTransactionDal(IDbContextFactory<SmartAgriContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
