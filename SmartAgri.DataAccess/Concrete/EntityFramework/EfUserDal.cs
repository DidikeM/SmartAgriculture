using Microsoft.EntityFrameworkCore;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Concrete;

namespace SmartAgri.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SmartAgriContext>, IUserDal
    {
        public EfUserDal(IDbContextFactory<SmartAgriContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
