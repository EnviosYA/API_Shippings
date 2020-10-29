using PS.Template.Application.Services.Base;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;

namespace PS.Template.Application.Services
{
    public class PaqueteService : BaseService<Paquete>, IPaqueteService
    {
        private readonly IPaqueteQuery _query;
        public PaqueteService(IPaqueteRepository repository, IPaqueteQuery query) : base(repository)
        {
            _query = query;
        }

        public ResponsePaqueteDto GetPaquete(int id)
        {
            // Validar que el paquete se encuentra en la base de datos
            bool existe = this._query.ExistePaquete(id);

            var result = _query.GetPaquete(id);

            return result;
        }
    }
}
