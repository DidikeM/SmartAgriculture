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

        public List<Reply> GetRepliesWithUserByTopicId(int topicId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Replies.Include(r => r.User).Where(r => r.TopicId == topicId).ToList();
            }
        }
    }
}
