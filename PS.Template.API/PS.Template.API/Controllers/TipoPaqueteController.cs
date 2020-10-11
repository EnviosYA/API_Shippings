using Microsoft.AspNetCore.Mvc;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Template.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TipoPaqueteController : ControllerBase
    {
        private readonly ITipoPaqueteService _service;
        public TipoPaqueteController(ITipoPaqueteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTipoPaquetes()
        {
            try
            {
                return new JsonResult(_service.GetTipoPaquetes()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
