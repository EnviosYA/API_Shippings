using PS.Template.Domain.DTO;
using System.Collections.Generic;

namespace PS.Template.Domain.Interfaces.Query
{
    public interface IEstadoQuery
    {
        public List<ResponseEstadoDto> GetEstados();
    }
}
