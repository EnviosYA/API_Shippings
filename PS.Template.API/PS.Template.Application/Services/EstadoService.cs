using PS.Template.Application.Services.Base;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace PS.Template.Application.Services
{
    public class EstadoService : BaseService<Estado>, IEstadoService
    {
        private readonly IEstadoQuery _query;

        public EstadoService(IEstadoRepository repository, IEstadoQuery query) : base(repository)
        {
            _query = query;
        }

        public List<ResponseEstadoDto> GetEstado()
        {
            return this._query.GetEstados();
        }
    }
}
