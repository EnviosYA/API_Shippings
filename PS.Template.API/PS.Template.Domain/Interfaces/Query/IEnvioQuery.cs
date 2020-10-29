using PS.Template.Domain.DTO;

namespace PS.Template.Domain.Interfaces.Query
{
    public interface IEnvioQuery
    {
        public ValorPaqueteDto ValorPaquete(int tipoPaquete);
    }
}
