using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.Interfaces.Query
{
    public interface IEstadoQuery
    {
        public List<ResponseEstadoDto> GetEstados();
    }
}
