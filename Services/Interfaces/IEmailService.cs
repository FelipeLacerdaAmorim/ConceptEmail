using System.Threading.Tasks;
using ConceptEmail.Models;

namespace ConceptEmail.Interfaces.Services
{
    public interface IEmailService
    {
        Task<string> SendEmail(TemplateEmail model);
    }
}
