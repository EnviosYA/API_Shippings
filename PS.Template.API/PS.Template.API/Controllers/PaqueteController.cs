using Microsoft.AspNetCore.Mvc;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PS.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : ControllerBase
    {
        private readonly IPaqueteService _service;
        public PaqueteController(IPaqueteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(CreatePaqueteRequestDto paquete)
        {
            try
            {
                return new JsonResult(_service.CreatePaquete(paquete)) { StatusCode = 201 }; 
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPaquete(int id)
        {
            try
            {
                return new JsonResult(_service.GetPaquete(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
