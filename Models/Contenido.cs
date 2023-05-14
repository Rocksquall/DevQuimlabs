using System;
using System.Collections.Generic;

namespace DevQuimlabs.Models
{
    public partial class Contenido
    {
        public Contenido()
        {
            Actividads = new HashSet<Actividad>();
        }

        public int IdContenido { get; set; }
        public string? Categoria { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? IdProfesor { get; set; }

        public virtual ICollection<Actividad> Actividads { get; set; }
    }
}
