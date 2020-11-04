using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.Interfaces.Service
{
    public interface ISucursalPorEnvioService : IBaseService<SucursalPorEnvio>
    {
        public ResponseRequestDto CreateSucEnvio(CreateSucEnvioRequestDto sucEnvio);

        public List<ResponseSeguimientoDto> GetSucEnvio(int id);
    }
}
