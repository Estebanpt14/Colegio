namespace Colegio.Services;

public interface IEmailService
{
    void SendEmail(string asunto, ICollection<string> emailDestino, string texto);
}