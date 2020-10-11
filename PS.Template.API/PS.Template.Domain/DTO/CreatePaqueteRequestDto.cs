using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.DTO
{
    public class CreatePaqueteRequestDto
    {
        public int IdTipoPaquete { get; set; }
        public int Peso { get; set; }
        public int Dimension { get; set; }
        public int CodPaquete { get; set; }
    }
}
