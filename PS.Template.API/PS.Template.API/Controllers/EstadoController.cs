using Microsoft.AspNetCore.Mvc;
using PS.Template.Domain.Interfaces.Service;
using System;

namespace PS.Template.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _service;

        public EstadoController(IEstadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEstados()
        {
            try
            {
                return new JsonResult(_service.GetEstado()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
