using PS.Template.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.Interfaces.Query
{
    public interface IPaqueteQuery
    {
        public ResponsePaqueteDto GetPaquete(int id);
    }
}
