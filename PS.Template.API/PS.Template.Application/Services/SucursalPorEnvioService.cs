using PS.Template.Application.Services.Base;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace PS.Template.Application.Services
{
    public class SucursalPorEnvioService : BaseService<SucursalPorEnvio>, ISucursalPorEnvioService
    {
        private readonly ISucursalPorEnvioQuery _query;
        public SucursalPorEnvioService(ISucursalPorEnvioRepository repository, ISucursalPorEnvioQuery query) : base(repository)
        {
            _query = query;
        }

        public ResponseRequestDto CreateSucEnvio(CreateSucEnvioRequestDto sucEnvio)
        {
            var entity = new SucursalPorEnvio
            {
                IdEnvio = sucEnvio.IdEnvio,
                IdSucursal = sucEnvio.IdSucursal,
                IdEstado = sucEnvio.IdEstado,
                Fecha = DateTime.Now
            };

            Add(entity);

            return new ResponseRequestDto { Codigo = 201, Mensaje = "Seguimiento creado correctamente" };
        }

        public List<ResponseSucEnvioDto> GetSucEnvio(int id)
        {
            return _query.GetSucEnvio(id);
        }
    }
}
