using PS.Template.Domain.DTO;
using PS.Template.Domain.Entities;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.RequestApis;
using PS.Template.Domain.Interfaces.Service;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using TP2.REST.Domain.DTO;

namespace PS.Template.Application.Services
{
    public class EnvioService : IEnvioService
    {
        private readonly IEnvioRepository _repository;
        private readonly IEnvioQuery _query;
        private readonly IGenerateRequest _generateRequest;

        public EnvioService(IEnvioRepository repository, IEnvioQuery query, IGenerateRequest generateRequest)
        {
            _repository = repository;
            _query = query;
            _generateRequest = generateRequest;
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
                    // Valido que tenga peso y volumen
                    if (!TienePesoYVolumen(paquetes))
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "No ingresó peso o medida en algún paquete" };
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
                    if (TienePesoOVolumen(paquetes))
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
                    if (TienePesoOVolumen(paquetes))
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "No debe ingresar peso o medidas" };
                    break;

                // Telegrama
                case 4:
                    // Validar que es uno solo
                    if (paquetes.Count > 1)
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "Solo puede ingresar una carta documento" };
                    // Validar que no ingresó peso o medidas
                    if (TienePesoOVolumen(paquetes))
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "No debe ingresar peso o medidas" };
                    break;
                
                // Carta simple
                case 5:
                    // Validar que no ingresó peso o medidas
                    if (TienePesoOVolumen(paquetes))
                        return new ResponseRequestDto { Codigo = 400, Mensaje = "No debe ingresar peso o medidas" };
                    // Calculo el costo
                    costo = costo * paquetes.Count;
                    break;

                default:
                    return new ResponseRequestDto { Codigo = 400, Mensaje = "Tipo de paquete inválido" };
            }

            var entityEnvio = new Envio {
                IdUserOrigen = ObtenerIdDirUser(envio.idUsuario),
                IdDireccionDestino = ObtenerIdDirDestino(envio.DireccionDestino),
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

        // Verifico que los tipos de paquetes sean todos iguales
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

        // Calcula el costo de las cajas
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

        // Calcula el peso total de las cajas
        public int PesoTotal(List<PaqueteDto> paquetes)
        {
            int peso = 0;

            foreach (PaqueteDto paquete in paquetes)
                peso += paquete.Peso;

            return peso;
        }

        // Calcula el volumen total de las cajas
        public int VolumenTotal(List<PaqueteDto> paquetes)
        {
            int volumen = 0;

            foreach (PaqueteDto paquete in paquetes)
                volumen += paquete.Ancho * paquete.Largo * paquete.Alto;

            return volumen;
        }

        // Verifica si un tipo de paquete tiene peso o medidas
        public bool TienePesoOVolumen(List<PaqueteDto> paquetes)
        {
            bool tiene = false;

            foreach (PaqueteDto paquete in paquetes)
            {
                if (paquete.Peso != 0 || paquete.Ancho != 0 || paquete.Largo != 0 || paquete.Alto != 0)
                    tiene = true;
            }

            return tiene;
        }

        // Verifica si una caja tiene peso y medidas
        public bool TienePesoYVolumen(List<PaqueteDto> paquetes)
        {
            bool tiene = true;

            foreach (PaqueteDto paquete in paquetes)
            {
                if (paquete.Peso == 0 || paquete.Ancho == 0 || paquete.Largo == 0 || paquete.Alto == 0)
                    tiene = false;
            }

            return tiene;
        }
        
        // Obtengo Id Direccion Destino
        public int ObtenerIdDirDestino(DireccionDTO direccion)
        {
            string uri = _generateRequest.GetUri(1);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(direccion);
            GenericCreatedResponseDTO user = _generateRequest.ConsultarApiRest<GenericCreatedResponseDTO>(uri, request).First();
            return int.Parse(user.Id);
        }

        // Obtener Direccion de un usuario
        public int ObtenerIdDirUser(int iduser)
        {
            string uri = _generateRequest.GetUri(2);
            RestRequest request = new RestRequest(Method.GET);
            request.AddQueryParameter("id", iduser.ToString());
            ResponseUsuarios user = _generateRequest.ConsultarApiRest<ResponseUsuarios>(uri, request).First();
            return user.IdDireccion;
        }
    }
}