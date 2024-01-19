using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace Colegio.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendEmail(string asunto, ICollection<string> emailDestino, string texto)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("colegio_correo34@gmail.com"));
        foreach (var emailR in emailDestino)
        {
            email.To.Add(MailboxAddress.Parse(emailR));
        }
        email.Subject = asunto;

        var templatePath = "Resources/mail.html";
        var template = File.ReadAllText(templatePath);
        template = template.Replace("{ASUNTO_DEL_CORREO}", asunto)
            .Replace("{CUERPO_DEL_CORREO}", texto);


        email.Body = new TextPart(TextFormat.Html) { Text = template };

        var smtp = new SmtpClient();
        smtp.Connect(_configuration.GetSection("Email:Host").Value,
            int.Parse(_configuration.GetSection("Email:Port").Value!),
            SecureSocketOptions.StartTls);
        smtp.Authenticate(_configuration.GetSection("Email:Username").Value,
            _configuration.GetSection("Email:Password").Value);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}