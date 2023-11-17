using Microsoft.EntityFrameworkCore;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Concrete;

namespace SmartAgri.DataAccess.Concrete.EntityFramework
{
    public class EfReplyDal : EfEntityRepositoryBase<Reply, SmartAgriContext>, IReplyDal
    {
        private readonly IDbContextFactory<SmartAgriContext> _contextFactory;
        public EfReplyDal(IDbContextFactory<SmartAgriContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
