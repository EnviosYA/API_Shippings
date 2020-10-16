using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Query;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PS.Template.AccessData.Query
{
    public class EnvioQuery : IEnvioQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public EnvioQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            _connection = connection;
            _sqlKataCompiler = sqlKataCompiler;
        }

        public ValorPaqueteDto ValorPaquete(int tipoPaquete)
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("TipoPaquete")
                .Select("TipoPaquete.Valor")
                .Where("idTipoPaquete", tipoPaquete)
                .Get<ValorPaqueteDto>()
                .FirstOrDefault();

            return query;
        }
    }
}
