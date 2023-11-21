using MimeKit;
using SmartAgri.WebUI.Mailing.Messages;
using MailKit.Net.Smtp;


namespace SmartAgri.WebUI.Mailing
{
	public class EmailSender : IEmailSender
	{
		private readonly EmailConfiguration _emailConfig;
		public EmailSender(EmailConfiguration emailConfig)
		{
			_emailConfig = emailConfig;
		}
		public void SendEmail(IMessage message)
		{
			var emailMessage = CreateEmailMessage(message);
			Send(emailMessage);
		}

		private MimeMessage CreateEmailMessage(IMessage message)
		{
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress(_emailConfig.UserName,_emailConfig.From));
			emailMessage.To.AddRange(message.To);
			emailMessage.Subject = message.Subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
			return emailMessage;
		}
		private void Send(MimeMessage mailMessage)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
					client.AuthenticationMechanisms.Remove("XOAUTH2");
					client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
					client.Send(mailMessage);
				}
				catch
				{
					Console.WriteLine("Error sending email");
				}
				finally
				{
					client.Disconnect(true);
				}
			}
		}
	}
}
