using Microsoft.EntityFrameworkCore;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Concrete;

namespace SmartAgri.DataAccess.Concrete.EntityFramework
{
    public class EfTopicDal : EfEntityRepositoryBase<Topic, SmartAgriContext>, ITopicDal
    {
        private readonly IDbContextFactory<SmartAgriContext> _contextFactory;
        public EfTopicDal(IDbContextFactory<SmartAgriContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Topic GetTopicWithRepliesById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Topics.Include(x => x.Replies).FirstOrDefault(x => x.Id == id)!;
            }
        }
    }
}
