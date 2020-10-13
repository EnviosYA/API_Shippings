using PS.Template.Domain.Commands;
using PS.Template.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.Interfaces.Repositories
{
    public interface IEnvioRepository
    {
        void Add<T>(T entity) where T : class;

        void SaveChanges();
    }
}
