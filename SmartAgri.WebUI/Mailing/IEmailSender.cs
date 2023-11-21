using SmartAgri.WebUI.Mailing.Messages;

namespace SmartAgri.WebUI.Mailing
{
	public interface IEmailSender
	{
		void SendEmail(IMessage message);
	}
}
