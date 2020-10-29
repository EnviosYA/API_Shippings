using PS.Template.AccessData.Commands;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Repositories;

namespace PS.Template.AccessData.Repositories
{
    public class SucursalPorEnvioRepository : GenericsRepository<SucursalPorEnvio>, ISucursalPorEnvioRepository
    {
        public SucursalPorEnvioRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
