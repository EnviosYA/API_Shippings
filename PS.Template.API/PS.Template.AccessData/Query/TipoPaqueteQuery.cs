using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Query;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PS.Template.AccessData.Query
{
    public class TipoPaqueteQuery : ITipoPaqueteQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _compiler;

        public TipoPaqueteQuery(IDbConnection connection, Compiler compiler)
        {
            _connection = connection;
            _compiler = compiler;
        }

        public List<ResponseTipoPaqueteDto> GetAllTipoPaquetes()
        {
            var db = new QueryFactory(_connection, _compiler);

            var query = db.Query("TipoPaquete");

            var result = query.Get<ResponseTipoPaqueteDto>();

            return result.ToList();
        }
    }
}
