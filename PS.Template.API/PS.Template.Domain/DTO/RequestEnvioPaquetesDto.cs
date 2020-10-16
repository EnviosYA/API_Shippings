using System.Collections.Generic;

namespace PS.Template.Domain.DTO
{
    public class RequestEnvioPaquetesDto
    {
        public int IdSucOrigen { get; set; }
        public int IdSucDestino { get; set; }
        public int IdUserOrigen { get; set; }
        public int IdUserDestino { get; set; }
        public List<PaqueteDto> Paquetes { get; set; }
    }
}
