using MimeKit;

namespace SmartAgri.WebUI.Mailing.Messages
{
    public class GuestMessageReplyMessage : IMessage
    {
        public GuestMessageReplyMessage(string userName, IEnumerable<string> to, string content, string subject)
        {
            To = new List<MailboxAddress>();
            UserName = userName;
            To.AddRange(to.Select(x => new MailboxAddress(UserName, x)));
            Subject = subject;
            Content = content;
        }
        public List<MailboxAddress> To { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
