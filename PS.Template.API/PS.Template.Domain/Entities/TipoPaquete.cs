using System.Collections.Generic;

namespace PS.Template.Domain.Entities
{
    public partial class TipoPaquete
    {
        public TipoPaquete()
        {
            Paquete = new HashSet<Paquete>();
        }

        public int IdTipoPaquete { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }

        public virtual ICollection<Paquete> Paquete { get; set; }
    }
}
