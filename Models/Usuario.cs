using System;
using System.Collections.Generic;

namespace DevQuimlabs.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Profesors = new HashSet<Profesor>();
        }

        public int IdUsuario { get; set; }
        public int? Identificacion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public int? IdRol { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }
        public virtual ICollection<Profesor> Profesors { get; set; }
    }
}
