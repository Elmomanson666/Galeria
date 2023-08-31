using System;
using System.Collections.Generic;

namespace Galeria.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdProducto { get; set; }
        public int IdCuadro { get; set; }
        public string? Existencias { get; set; }
        public string? Nombre { get; set; }
        public string? Precio { get; set; }

        public virtual Cuadro IdCuadroNavigation { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
