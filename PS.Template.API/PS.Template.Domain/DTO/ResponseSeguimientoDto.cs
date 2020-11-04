using System;

namespace PS.Template.Domain.DTO
{
    public class ResponseSeguimientoDto
    {
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
