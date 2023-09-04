using EmailNotification.Interfaces;
using EmailNotification.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IEmailService service;

        public AccountsController(IEmailService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> SendAsync(EmailMessage message)
        {
                await this.service.SendAsync(message);
            return Ok(); 
        }
    }
}
