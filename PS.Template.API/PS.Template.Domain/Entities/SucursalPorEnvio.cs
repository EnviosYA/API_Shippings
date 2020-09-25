using System;
using System.Collections.Generic;

namespace PS.Template.Domain.Entities
{
    public partial class SucursalPorEnvio
    {
        public int IdSucursalPorEnvio { get; set; }
        public int IdEnvio { get; set; }
        public int IdSucursal { get; set; }
        public int IdEstado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Envio IdEnvioNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
    }
}
