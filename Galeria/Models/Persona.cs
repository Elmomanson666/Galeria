using System;
using System.Collections.Generic;

namespace Galeria.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Artista = new HashSet<Artistum>();
            Clientes = new HashSet<Cliente>();
        }

        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Cedula { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Edad { get; set; }
        public string? CiudadRecidencia { get; set; }

        public virtual ICollection<Artistum> Artista { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
