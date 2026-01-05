namespace ClothingStore.Core.Models.Email
{
    public class EmailOptions
    {
        public string SmtpServer { get; set; } = string.Empty;
        public int SmtpPort { get; set; } = 587;
        public bool UseSsl { get; set; } = true;

        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FromEmail { get; set; } = string.Empty;
        public string FromName { get; set; } = "Online Clothing Store";
        public string ToEmail { get; set; } = string.Empty;
    }
}
