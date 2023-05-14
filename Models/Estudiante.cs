using System;
using System.Collections.Generic;

namespace DevQuimlabs.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Actividads = new HashSet<Actividad>();
        }

        public int IdEstudiante { get; set; }
        public string? Grado { get; set; }
        public int? IdUsuario { get; set; }

        public virtual ICollection<Actividad> Actividads { get; set; }
    }
}
