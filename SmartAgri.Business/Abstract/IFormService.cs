using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Business.Abstract
{
    public interface IFormService
    {
        void AddReply(Reply reply);
        void AddTopic(Topic topic);
        Topic GetTopic(int id);
        List<Topic> GetTopics();
    }
}
