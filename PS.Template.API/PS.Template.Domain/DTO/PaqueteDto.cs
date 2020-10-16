using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.DTO
{
    public class PaqueteDto
    {
        public int Peso { get; set; }
        public int Largo { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public int IdTipoPaquete { get; set; }
    }
}
