using System;
using System.Collections.Generic;

namespace DevQuimlabs.Models
{
    public partial class Actividad
    {
        public int IdActividad { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? Calificacion { get; set; }
        public int? IdEstudiante { get; set; }
        public int? IdContenido { get; set; }

        public virtual Contenido? IdContenidoNavigation { get; set; }
        public virtual Estudiante? IdEstudianteNavigation { get; set; }
    }
}
