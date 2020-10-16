using System.Collections.Generic;

namespace PS.Template.Domain.Entities
{
    public partial class Estado
    {
        public Estado()
        {
            SucursalPorEnvio = new HashSet<SucursalPorEnvio>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<SucursalPorEnvio> SucursalPorEnvio { get; set; }
    }
}
