using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Ruletum
    {
        public Ruletum()
        {
            ResultadoApuesta = new HashSet<ResultadoApuestum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<ResultadoApuestum> ResultadoApuesta { get; set; }
    }
}
