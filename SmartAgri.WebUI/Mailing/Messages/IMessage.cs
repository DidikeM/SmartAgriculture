using MimeKit;

namespace SmartAgri.WebUI.Mailing.Messages
{
	public interface IMessage
	{
		public List<MailboxAddress> To { get; set; }
		public string UserName { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
	}
}
