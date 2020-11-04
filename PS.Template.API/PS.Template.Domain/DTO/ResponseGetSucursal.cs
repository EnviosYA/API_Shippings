namespace PS.Template.Domain.DTO
{
    public class ResponseGetSucursal
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }

        //Direccion
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }

        //Localidad
        public string NombreLocalidad { get; set; }
        public int Cp { get; set; }

        //Provincia
        public string NombreProvincia { get; set; }

        //EstadoSucursal
        public string Estado { get; set; }
    }
}
