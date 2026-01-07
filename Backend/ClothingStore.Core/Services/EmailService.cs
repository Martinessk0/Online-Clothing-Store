using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Contact;
using ClothingStore.Core.Models.Email;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace ClothingStore.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _options;

        public EmailService(IOptions<EmailOptions> options)
        {
            _options = options.Value;

        }

        public async Task SendContactEmailAsync(ContactRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentException("Email is required.", nameof(request.Email));

            if (string.IsNullOrWhiteSpace(request.Message))
                throw new ArgumentException("Message is required.", nameof(request.Message));

            var body = $@"Име: {request.Name ?? "(не е посочено)"}
                    Имейл: {request.Email}

                    Съобщение:
                    {request.Message}";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Online Clothing Store", _options.FromEmail));
            message.To.Add(new MailboxAddress("", _options.ToEmail));
            message.Subject = "Ново съобщение от контактната форма";
            message.Body = new TextPart(TextFormat.Plain) { Text = body };

            message.ReplyTo.Add(new MailboxAddress(request.Name ?? request.Email, request.Email));

            using var client = new SmtpClient();

            try
            {
                Console.WriteLine($"[EMAIL] Connecting to {_options.SmtpServer}:{_options.SmtpPort} ...");

                await client.ConnectAsync(
                    _options.SmtpServer,
                    _options.SmtpPort,
                    SecureSocketOptions.SslOnConnect);

                await client.AuthenticateAsync(_options.UserName, _options.Password);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                Console.WriteLine("[EMAIL] Sent OK via MailKit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EMAIL][MAILKIT ERROR] " + ex);
                throw;
            }
        }

    }
}
