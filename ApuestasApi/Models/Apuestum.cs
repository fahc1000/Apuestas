using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class Apuestum
    {
        public Apuestum()
        {
            ResultadoApuesta = new HashSet<ResultadoApuestum>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Apuesta { get; set; }
        public decimal ValorApuesta { get; set; }
        public int IdRuleta { get; set; }
        public DateTime? FechaApuesta { get; set; }
        public bool? Activa { get; set; }

        public virtual UsuarioApostador IdUsuarioNavigation { get; set; }
        public virtual ICollection<ResultadoApuestum> ResultadoApuesta { get; set; }
    }
}
