using PS.Template.Application.Services.Base;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace PS.Template.Application.Services
{
    public class TipoPaqueteService : BaseService<TipoPaquete>, ITipoPaqueteService
    {
        private readonly ITipoPaqueteQuery _query;

        public TipoPaqueteService(ITipoPaqueteRepository repository, ITipoPaqueteQuery query) : base(repository)
        {
            _query = query;
        }

        public List<ResponseTipoPaqueteDto> GetTipoPaquetes()
        {
            var result = _query.GetAllTipoPaquetes();

            return result;
        }
    }
}
