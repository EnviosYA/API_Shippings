using System.Collections.Generic;

namespace PS.Template.Domain.DTO
{
    public class RequestEnvioPaquetesDto
    {
        public DireccionDTO DireccionOrigen { get; set; }
        public DireccionDTO DireccionDestino { get; set; }
        public List<PaqueteDto> Paquetes { get; set; }
    }
}
