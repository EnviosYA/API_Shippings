using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Template.Domain.Entities
{
    public partial class Paquete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaquete { get; set; }
        public int Peso { get; set; }
        public int Largo { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public int Dimension { get; set; }
        public int IdTipoPaquete { get; set; }
        public int IdEnvio { get; set; }

        public virtual TipoPaquete IdTipoPaqueteNavigation { get; set; }
        public virtual Envio EnvioNavigation { get; set; }
    }
}
