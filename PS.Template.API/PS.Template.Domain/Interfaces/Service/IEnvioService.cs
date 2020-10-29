using PS.Template.Domain.DTO;

namespace PS.Template.Domain.Interfaces.Service
{
    public interface IEnvioService
    {
        public ResponseRequestDto CreateEnvioPaquetes(RequestEnvioPaquetesDto envio);
    }
}
