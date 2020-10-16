using PS.Template.Domain.DTO;
using System.Collections.Generic;

namespace PS.Template.Domain.Interfaces.Query
{
    public interface ITipoPaqueteQuery
    {
        public List<ResponseTipoPaqueteDto> GetAllTipoPaquetes();
    }
}
