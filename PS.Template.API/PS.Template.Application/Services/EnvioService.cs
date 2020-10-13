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
    public class EnvioService : IEnvioService
    {
        private readonly IEnvioRepository _repository;
        private readonly IEnvioQuery _query;

        public EnvioService(IEnvioRepository repository, IEnvioQuery query)
        {
            this._repository = repository;
            this._query = query;
        }

        public GenericResponseDto CreateEnvioPaquetes(RequestEnvioPaquetesDto envio)
        {
            var entityEnvio = new Envio { 
                IdSucOrigen = envio.IdSucOrigen,
                IdSucDestino = envio.IdSucDestino,
                IdUserOrigen = envio.IdUserOrigen,
                IdUserDestino = envio.IdUserDestino,
                Costo = envio.Costo
            };

            this._repository.Add<Envio>(entityEnvio);
            this._repository.SaveChanges();

            foreach (PaqueteDto paquete in envio.Paquetes)
            {
                var entityPaquete = new Paquete
                {
                    Peso = paquete.Peso,
                    Valor = paquete.Valor,
                    Largo = paquete.Largo,
                    Ancho = paquete.Ancho,
                    Alto = paquete.Alto,
                    Dimension = paquete.Largo * paquete.Ancho * paquete.Alto,
                    IdTipoPaquete = paquete.IdTipoPaquete,
                    IdEnvio = entityEnvio.IdEnvio
                };

                this._repository.Add<Paquete>(entityPaquete);
            }

            this._repository.SaveChanges();

            return new GenericResponseDto { Id = entityEnvio.IdEnvio.ToString(), Entidad = "Envio" };
        }
    }
}
