using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Service.Base;

namespace PS.Template.Domain.Interfaces.Service
{
    public interface IPaqueteService : IBaseService<Paquete>
    {
        public ResponsePaqueteDto GetPaquete(int id);
    }
}
