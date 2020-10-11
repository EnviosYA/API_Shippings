using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.DTO
{
    public class CreateSucEnvioRequestDto
    {
        public int IdEnvio { get; set; }
        public int IdSucursal { get; set; }
        public int IdEstado { get; set; }
        public int CodPaquete { get; set; }
    }
}
