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
    public class PaqueteQuery : IPaqueteQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public PaqueteQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public ResponsePaqueteDto GetPaquete(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Paquete")
                .Select("Paquete.Valor",
                "TipoPaquete.Descripcion AS TipoPaquete")
                .Join("TipoPaquete", "TipoPaquete.idTipoPaquete", "Paquete.idTipoPaquete")
                .Where("idPaquete", id)
                .Get<ResponsePaqueteDto>()
                .FirstOrDefault();

            return query;
        }
    }
}
