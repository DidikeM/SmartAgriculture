using Microsoft.AspNetCore.Mvc;
using SmartAgri.Business.Abstract;
using SmartAgri.Entities.Concrete;

namespace SmartAgri.WebUI.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public IActionResult GetTopics()
        {
            List<Topic> topics = _formService.GetTopics();
            return Json(topics);
        }

        [HttpGet]
        public IActionResult GetTopic(int id)
        {
            Topic topic = _formService.GetTopic(id);
            if (topic == null)
            {
                return NotFound();
            }
            foreach (var reply in topic.Replies)
            {
                reply.Topic = null!;
                reply.User = null!;
            }
            return Json(topic);
        }

        [HttpPost]
        public IActionResult CreateTopic(Topic topic)
        {
            topic.Date = DateTime.Now;
            _formService.AddTopic(topic);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateReply(Reply reply)
        {
            reply.Date = DateTime.Now;
            _formService.AddReply(reply);
            return Ok();
        }
    }
}
