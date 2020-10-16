using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;
using System.Collections.Generic;

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

        public ResponseRequestDto CreateEnvioPaquetes(RequestEnvioPaquetesDto envio)
        {
            const int pesoMax = 100;
            const int volMax = 1200000;

            List<PaqueteDto> paquetes = envio.Paquetes;

            int costo = _query.ValorPaquete(paquetes[0].IdTipoPaquete).Valor;

            // No puede ingresar distintos tipos de paquetes
            if (!ValidarTipoPaquetes(paquetes))
                return new ResponseRequestDto { Codigo = 400, Mensaje = "Los tipos de paquetes no coinciden" };

            switch (envio.Paquetes[0].IdTipoPaquete)
            {
                // Caja
                case 1:
                    // Validar peso máximo y volumen máximo
                    if (PesoTotal(paquetes) > pesoMax)
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "Supera el peso máximo" };

                    if (VolumenTotal(paquetes) > volMax)
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "Supera el volumen máximo" };

                    // Calcular costo de envío de cajas
                    costo += CalcularCostoPaquetes(paquetes);
                    break;

                // Bolsin
                case 2:
                    // Validar que no ingresó peso o medidas
                    if (TienePesoVolumen(paquetes))
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "No debe ingresar peso o medidas" };
                    // Calculo el costo
                    costo = costo * paquetes.Count;
                    break;

                // Carta documento
                case 3:
                    // Validar que es uno solo
                    if (paquetes.Count > 1)
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "Solo puede ingresar una carta documento" };
                    // Validar que no ingresó peso o medidas
                    if (TienePesoVolumen(paquetes))
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "No debe ingresar peso o medidas" };
                    break;

                // Telegrama
                case 4:
                    // Validar que es uno solo
                    if (paquetes.Count > 1)
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "Solo puede ingresar una carta documento" };
                    // Validar que no ingresó peso o medidas
                    if (TienePesoVolumen(paquetes))
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "No debe ingresar peso o medidas" };
                    break;
                
                // Carta simple
                case 5:
                    // Validar que no ingresó peso o medidas
                    if (TienePesoVolumen(paquetes))
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "No debe ingresar peso o medidas" };
                    // Calculo el costo
                    costo = costo * paquetes.Count;
                    break;

                default:
                    return new ResponseRequestDto { Codigo = 400, Mensaje = "Tipo de paquete inválido" };
            }

            var entityEnvio = new Envio { 
                IdSucOrigen = envio.IdSucOrigen,
                IdSucDestino = envio.IdSucDestino,
                IdUserOrigen = envio.IdUserOrigen,
                IdUserDestino = envio.IdUserDestino,
                Costo = costo
            };

            this._repository.Add<Envio>(entityEnvio);
            this._repository.SaveChanges();

            foreach (PaqueteDto paquete in paquetes)
            {
                var entityPaquete = new Paquete
                {
                    Peso = paquete.Peso,
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

            return new ResponseRequestDto { Codigo = 201, Mensaje = "Envío creado correctamente" };
        }

        public bool ValidarTipoPaquetes(List<PaqueteDto> paquetes)
        {
            int tipoPaquete = paquetes[0].IdTipoPaquete;
            bool iguales = true;

            foreach(PaqueteDto paquete in paquetes)
            {
                if (paquete.IdTipoPaquete != tipoPaquete)
                    iguales = false;
            }

            return iguales;
        }

        public int CalcularCostoPaquetes(List<PaqueteDto> paquetes)
        {
            int costo;

            int peso = 0;

            foreach (PaqueteDto paquete in paquetes)
            {
                peso += paquete.Peso;
            }

            if (peso > 0 && peso < 15)
                costo = 200;
            else if (peso > 15 && peso < 30)
                costo = 500;
            else if (peso > 30 && peso < 45)
                costo = 700;
            else if (peso > 45 && peso < 60)
                costo = 900;
            else
                costo = 1200;

            return costo;
        }

        public int PesoTotal(List<PaqueteDto> paquetes)
        {
            int peso = 0;

            foreach (PaqueteDto paquete in paquetes)
                peso += paquete.Peso;

            return peso;
        }

        public int VolumenTotal(List<PaqueteDto> paquetes)
        {
            int volumen = 0;

            foreach (PaqueteDto paquete in paquetes)
                volumen += paquete.Ancho * paquete.Largo * paquete.Alto;

            return volumen;
        }

        public bool TienePesoVolumen(List<PaqueteDto> paquetes)
        {
            bool tiene = false;

            foreach (PaqueteDto paquete in paquetes)
            {
                if (paquete.Peso != 0 || paquete.Ancho != 0 || paquete.Largo != 0 || paquete.Alto != 0)
                    tiene = true;
            }

            return tiene;
        }
    }
}
