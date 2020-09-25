using System;
using System.Collections.Generic;

namespace PS.Template.Domain.Entities
{
    public partial class Paquete
    {
        public Paquete()
        {
            Envio = new HashSet<Envio>();
        }

        public int IdPaquete { get; set; }
        public int Peso { get; set; }
        public int Valor { get; set; }
        public int CodPaquete { get; set; }
        public int Dimension { get; set; }
        public int IdTipoPaquete { get; set; }

        public virtual TipoPaquete IdTipoPaqueteNavigation { get; set; }
        public virtual ICollection<Envio> Envio { get; set; }
    }
}
