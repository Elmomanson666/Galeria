using System;
using System.Collections.Generic;

namespace Galeria.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdCliente { get; set; }
        public int? IdPersona { get; set; }
        public string? Dierección { get; set; }
        public string? CodigoPostal { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
