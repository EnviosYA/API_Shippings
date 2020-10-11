using PS.Template.Application.Services.Base;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Application.Services
{
    public class PaqueteService : BaseService<Paquete>, IPaqueteService
    {
        private readonly IPaqueteQuery _query;
        public PaqueteService(IPaqueteRepository repository, IPaqueteQuery query) : base(repository)
        {
            _query = query;
        }

        public GenericResponseDto CreatePaquete(CreatePaqueteRequestDto paquete)
        {
            int valor = _query.ValorPaquete(paquete.IdTipoPaquete).Valor;

            int valorPaquete = valor;

            if (paquete.IdTipoPaquete == 1)
            {
                valorPaquete += (int)Math.Round(valor + paquete.Peso * 40 + paquete.Dimension * 0.0025);
            }

            var entity = new Paquete
            {
                Peso = paquete.Peso,
                Dimension = paquete.Dimension,
                Valor = valorPaquete,
                IdTipoPaquete = paquete.IdTipoPaquete
            };

            Add(entity);

            return new GenericResponseDto { Entidad = "Paquete", Id = entity.IdPaquete.ToString() };
        }

        public ResponsePaqueteDto GetPaquete(int id)
        {
            var result = _query.GetPaquete(id);

            return result;
        }
    }
}
