using PS.Template.AccessData.Commands;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.AccessData.Repositories
{
    public class TipoPaqueteRepository : GenericsRepository<TipoPaquete>, ITipoPaqueteRepository
    {
        public TipoPaqueteRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
