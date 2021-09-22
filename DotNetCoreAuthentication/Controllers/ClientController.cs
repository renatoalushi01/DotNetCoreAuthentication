using AutoMapper;
using DotNetCoreAuthentication.Service;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IMailBoxService _service;

        public ClientController(IMailBoxService service, IMapper mapper, IEmailSender emailSender)
        {
            _service = service;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _service.GetMailBoxAsync();
            if (clients == null)
                return BadRequest("No Clients");

            return Ok(clients);
        }
    }
}
