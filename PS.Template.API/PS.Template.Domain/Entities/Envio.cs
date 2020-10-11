using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Template.Domain.Entities
{
    public partial class Envio
    {
        public Envio()
        {
            Paquete = new HashSet<Paquete>();
            SucursalPorEnvio = new HashSet<SucursalPorEnvio>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEnvio { get; set; }
        public int IdSucOrigen { get; set; }
        public int IdSucDestino { get; set; }
        public int IdUserOrigen { get; set; }
        public int IdUserDestino { get; set; }
        public int Costo { get; set; }

        public virtual ICollection<Paquete> Paquete { get; set; }
        public virtual ICollection<SucursalPorEnvio> SucursalPorEnvio { get; set; }
    }
}
