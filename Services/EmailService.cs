using System;
using System.Net.Mail;
using System.Threading.Tasks;
using ConceptEmail.Interfaces.Services;
using ConceptEmail.Models;
using FluentEmail.Core;
using FluentEmail.Smtp;

namespace ConceptEmail.Services
{
    public class EmailService : IEmailService
    {
        public async Task<string> SendEmail(TemplateEmail model)
        {
            try
            {
                var sender = new SmtpSender(() => new SmtpClient(host: "localhost")
                {
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Port = 25
                });

                Email.DefaultSender = sender;

                var email = await Email
                    .From(emailAddress: model.SenderEmail)
                    .To(emailAddress: model.ReceiverEmail, name: model.ReceiverName)
                    .Subject(subject: model.Subject)
                    .Body(body: model.Body)
                    .SendAsync();

                return ($"Serviço funfando pro {model.SenderEmail}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
