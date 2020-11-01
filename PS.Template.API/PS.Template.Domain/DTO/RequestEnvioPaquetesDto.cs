using System.Collections.Generic;

namespace PS.Template.Domain.DTO
{
    public class RequestEnvioPaquetesDto
    {
        public int IdUserOrigen { get; set; }
        public int IdDireccionDestino { get; set; }
        public List<PaqueteDto> Paquetes { get; set; }
    }
}
