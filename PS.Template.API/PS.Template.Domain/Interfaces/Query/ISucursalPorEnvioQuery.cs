using PS.Template.Domain.DTO;
using System.Collections.Generic;

namespace PS.Template.Domain.Interfaces.Query
{
    public interface ISucursalPorEnvioQuery
    {
        public List<ResponseSucEnvioDto> GetSucEnvio(int id);
    }
}
