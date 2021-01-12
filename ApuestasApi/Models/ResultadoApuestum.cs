using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class ResultadoApuestum
    {
        public int Id { get; set; }
        public int IdRuleta { get; set; }
        public int? IdApuestaGanadora { get; set; }

        public virtual Apuestum IdApuestaGanadoraNavigation { get; set; }
        public virtual Ruletum IdRuletaNavigation { get; set; }
    }
}
