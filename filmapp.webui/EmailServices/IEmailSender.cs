using System.Threading.Tasks;

namespace filmapp.webui.EmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email,string subject,string htmlMessage) ;
    }
}