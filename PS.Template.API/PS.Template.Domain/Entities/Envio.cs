using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Template.Domain.Entities
{
    public partial class Envio
    {
        public Envio()
        {
            SucursalPorEnvio = new HashSet<SucursalPorEnvio>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEnvio { get; set; }
        public int IdSucOrigen { get; set; }
        public int IdSucDestino { get; set; }
        public int IdUserOrigen { get; set; }
        public int IdUserDestino { get; set; }
        public int CodPaquete { get; set; }
        public int Costo { get; set; }

        public virtual Paquete CodPaqueteNavigation { get; set; }
        public virtual ICollection<SucursalPorEnvio> SucursalPorEnvio { get; set; }
    }
}
