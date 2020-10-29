using Microsoft.AspNetCore.Mvc;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Service;
using System;

namespace PS.Template.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioService _service;

        public EnvioController(IEnvioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostEnvioPaquetes(RequestEnvioPaquetesDto request)
        {
            try
            {
                return new JsonResult(_service.CreateEnvioPaquetes(request)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
