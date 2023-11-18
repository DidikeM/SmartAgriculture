using SmartAgri.Entities.Concrete;

namespace SmartAgri.DataAccess.Abstract
{
    public interface IReplyDal : IEntityRepository<Reply>
    {
        List<Reply> GetRepliesWithUserByTopicId(int topicId);
    }
}
