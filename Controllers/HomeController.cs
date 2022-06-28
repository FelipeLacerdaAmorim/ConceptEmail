using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ConceptEmail.Models;
using ConceptEmail.Services;
using ConceptEmail.Interfaces.Services;

namespace ConceptEmail.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IEmailService emailService;

        public TestController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        public async Task<string> Post(TemplateEmail model)
        {
            try
            {
                string _message = await emailService.SendEmail(model);
                return (_message);
            }
            catch (Exception ex)
            {
                return ($"Error while trying to send email. Error: {ex.Message}");
            }
        }
    }
}
