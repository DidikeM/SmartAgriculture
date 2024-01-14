namespace SmartAgri.WebUI.DTOs
{
    public class ReplyGuestMessageDto
    {
        public int GuestMessageId { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
