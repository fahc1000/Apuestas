using System;
using System.Collections.Generic;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class UsuarioApostador
    {
        public UsuarioApostador()
        {
            Apuesta = new HashSet<Apuestum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Credito { get; set; }

        public virtual ICollection<Apuestum> Apuesta { get; set; }
    }
}
