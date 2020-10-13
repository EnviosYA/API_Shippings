using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.DTO
{
    public class RequestEnvioPaquetesDto
    {
        public int IdSucOrigen { get; set; }
        public int IdSucDestino { get; set; }
        public int IdUserOrigen { get; set; }
        public int IdUserDestino { get; set; }
        public int Costo { get; set; }
        public List<PaqueteDto> Paquetes { get; set; }
    }
}
