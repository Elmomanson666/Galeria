using System;
using System.Collections.Generic;

namespace Galeria.Models
{
    public partial class Artistum
    {
        public Artistum()
        {
            Cuadros = new HashSet<Cuadro>();
        }

        public int IdArtista { get; set; }
        public int IdPersona { get; set; }
        public string? Estilo { get; set; }
        public string? Experiencia { get; set; }
        public string? Firma { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<Cuadro> Cuadros { get; set; }
    }
}
