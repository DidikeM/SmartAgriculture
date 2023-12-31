﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpGet, Authorize]
        public IActionResult GetTopics()
        {
            var asd = User.Claims;
            List<Topic> topics = _formService.GetTopicsWithUsers();
            foreach (var topic in topics)
            {
                topic.User.Topics = null!;
            }
            return Json(topics);
        }

        [HttpGet]
        public IActionResult GetTopic(int id)
        {
            Topic topic = _formService.GetTopicWithUserById(id);
            if (topic == null)
            {
                return NotFound();
            }
            topic.User.Topics = null!;
            return Json(topic);
        }

        [HttpPost]
        public IActionResult CreateTopic([FromBody] Topic topic)
        {
            topic.Date = DateTime.Now;
            _formService.AddTopic(topic);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetReplies(int topicId)
        {
            List<Reply> replies = _formService.GetRepliesWithUserByTopicId(topicId);

            foreach (var item in replies)
            {
                item.User.Replies = null!;
            }

            return Json(replies);
        }

        [HttpPost]
        public IActionResult CreateReply([FromBody] Reply reply)
        {
            reply.Date = DateTime.Now;
            _formService.AddReply(reply);
            return Ok();
        }
    }
}
