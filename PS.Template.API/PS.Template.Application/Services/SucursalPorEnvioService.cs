using PS.Template.Application.Services.Base;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.RequestApis;
using PS.Template.Domain.Interfaces.Service;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PS.Template.Application.Services
{
    public class SucursalPorEnvioService : BaseService<SucursalPorEnvio>, ISucursalPorEnvioService
    {
        private readonly ISucursalPorEnvioQuery _query;
        private readonly IGenerateRequest _request;

        public SucursalPorEnvioService(ISucursalPorEnvioRepository repository, 
            ISucursalPorEnvioQuery query, IGenerateRequest generate) : base(repository)
        {
            _query = query;
            _request = generate;
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

        public List<ResponseSeguimientoDto> GetSucEnvio(int id)
        {
            List<ResponseSucEnvioDto> sucPorEnvio = _query.GetSucEnvio(id);
            ResponseGetSucursal sucursal;
            List<ResponseSeguimientoDto> seguimientos = new List<ResponseSeguimientoDto>();

            foreach(ResponseSucEnvioDto seguimiento in sucPorEnvio)
            {
                sucursal = GetDataApi(seguimiento.IdSucursal).First();
                seguimientos.Add(new ResponseSeguimientoDto
                {
                    Estado = seguimiento.Estado,
                    Fecha = seguimiento.Fecha,
                    Nombre = sucursal.Nombre,
                    Latitud = sucursal.Latitud,
                    Longitud = sucursal.Longitud
                });
            }
            return seguimientos;
        }
        public IEnumerable<ResponseGetSucursal> GetDataApi(int idSucursal)
        {
            string uri = _request.GetUri(1);
            RestRequest request = new RestRequest(Method.GET);
            request.AddQueryParameter("idSucursal", idSucursal.ToString());
            IEnumerable<ResponseGetSucursal> sucursal = _request.ConsultarApiRest<ResponseGetSucursal>(uri, request);

            return sucursal;
        }
    }
}
