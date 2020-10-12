using PS.Template.Application.Services.Base;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Application.Services
{
    public class EnvioService : BaseService<Envio>, IEnvioService
    {
        private readonly IEnvioQuery _query;

        public EnvioService(IEnvioRepository repository, IEnvioQuery query) : base(repository)
        {
            this._query = query;
        }
    }
}
