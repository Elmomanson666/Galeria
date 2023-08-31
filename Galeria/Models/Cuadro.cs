using System;
using System.Collections.Generic;

namespace Galeria.Models
{
    public partial class Cuadro
    {
        public Cuadro()
        {
            Compras = new HashSet<Compra>();
            Productos = new HashSet<Producto>();
        }

        public int IdCuadro { get; set; }
        public int IdArtista { get; set; }
        public string? Nombre { get; set; }
        public string? Medidas { get; set; }
        public string? Materiales { get; set; }

        public virtual Artistum IdArtistaNavigation { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
