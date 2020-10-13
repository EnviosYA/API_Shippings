using PS.Template.AccessData.Commands;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.AccessData.Repositories
{
    public class EnvioRepository : IEnvioRepository
    {
        private readonly BaseDbContext _context;
        public EnvioRepository(BaseDbContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this._context.Add(entity);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
