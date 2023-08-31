using System;
using System.Collections.Generic;

namespace Galeria.Models
{
    public partial class Compra
    {
        public int IdCompras { get; set; }
        public int IdCliente { get; set; }
        public int? IdCuadro { get; set; }
        public int? IdProducto { get; set; }
        public string? PrecioTotal { get; set; }
        public string? DetalleCompra { get; set; }

        public virtual Cuadro IdCliente1 { get; set; } = null!;
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Producto? IdCuadroNavigation { get; set; }
    }
}
