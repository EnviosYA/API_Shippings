using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Query;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;
using System.Linq;

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

        public bool ExistePaquete(int id)
        {
            bool existe = false;

            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Paquete")
                        .Where("Paquete.idPaquete", "=", id)
                        .FirstOrDefault();

            if (query != null)
                existe = true;

            return existe;
        }

        public ResponsePaqueteDto GetPaquete(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Paquete")
                .Select("TipoPaquete.Descripcion AS TipoPaquete",
                "Paquete.Peso AS Peso",
                "Paquete.Ancho AS Ancho",
                "Paquete.Largo AS Largo",
                "Paquete.Alto AS Alto")
                .Join("TipoPaquete", "TipoPaquete.idTipoPaquete", "Paquete.idTipoPaquete")
                .Where("idPaquete", id)
                .Get<ResponsePaqueteDto>()
                .FirstOrDefault();

            return query;
        }
    }
}
