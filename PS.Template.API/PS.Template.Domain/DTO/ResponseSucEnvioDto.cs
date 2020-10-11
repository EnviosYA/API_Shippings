using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.DTO
{
    public class ResponseSucEnvioDto
    {
        public int IdSucursal { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
