using SmartAgri.Business.Abstract;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Business.Concrete
{
    public class FormService : IFormService
    {
        private readonly ITopicDal _topicDal;
        private readonly IReplyDal _replyDal;
        public FormService(ITopicDal topicDal, IReplyDal replyDal)
        {
            _topicDal = topicDal;
            _replyDal = replyDal;
        }

        public void AddReply(Reply reply)
        {
            _replyDal.Add(reply);
        }

        public void AddTopic(Topic topic)
        {
            _topicDal.Add(topic);
        }

        public Topic GetTopic(int id)
        {
            return _topicDal.GetTopicWithRepliesById(id);
        }

        public List<Topic> GetTopics()
        {
            return _topicDal.GetAll();
        }
    }
}
