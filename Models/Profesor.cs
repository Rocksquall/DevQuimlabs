using System;
using System.Collections.Generic;

namespace DevQuimlabs.Models
{
    public partial class Profesor
    {
        public int IdProfesor { get; set; }
        public string? Especialidad { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
