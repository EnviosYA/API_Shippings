using PS.Template.AccessData.Commands;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Repositories;

namespace PS.Template.AccessData.Repositories
{
    public class TipoPaqueteRepository : GenericsRepository<TipoPaquete>, ITipoPaqueteRepository
    {
        public TipoPaqueteRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
