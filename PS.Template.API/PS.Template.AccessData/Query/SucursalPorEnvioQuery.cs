using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Query;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PS.Template.AccessData.Query
{
    public class SucursalPorEnvioQuery : ISucursalPorEnvioQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public SucursalPorEnvioQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }
        public List<ResponseSucEnvioDto> GetSucEnvio(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("SucursalPorEnvio");

            var result = query.Select("SucursalPorEnvio.IdSucursal AS IdSucursal",
                "SucursalPorEnvio.Fecha AS Fecha",
                "Estado.Descripcion AS Estado"
                )
                .Join("Estado", "Estado.IdEstado", "SucursalPorEnvio.IdEstado")
                .Where("SucursalPorEnvio.IdEnvio", "=", id)
                .Get<ResponseSucEnvioDto>();

            return result.ToList();
        }
    }
}
