using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Service.Base;
using System.Collections.Generic;

namespace PS.Template.Domain.Interfaces.Service
{
    public interface IEstadoService : IBaseService<Estado>
    {
        public List<ResponseEstadoDto> GetEstado();
    }
}
