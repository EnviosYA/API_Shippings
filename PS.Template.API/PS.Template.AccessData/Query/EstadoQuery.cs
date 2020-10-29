using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Query;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PS.Template.AccessData.Query
{
    public class EstadoQuery : IEstadoQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public EstadoQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            _connection = connection;
            _sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseEstadoDto> GetEstados()
        {
            var db = new QueryFactory(_connection, _sqlKataCompiler);

            var query = db.Query("Estado")
                            .Get<ResponseEstadoDto>()
                            .ToList();

            return query;
        }
    }
}
