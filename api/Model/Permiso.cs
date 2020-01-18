using Interview.Model;
using System;

namespace InterView.Model
{
    /// <summary>
    /// Entity of Leave date of work.
    /// </summary>
    public class Permiso
    {
        /// <summary>
        /// Id of Leave
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        public string NombreEmpleado { get; set; }

        /// <summary>
        /// Employee LastName
        /// </summary>
        public string ApellidosEmpleado { get; set; }

        /// <summary>
        /// Type of Leave
        /// </summary>
        public TipoPermiso TipoPermiso { get; set; }

        /// <summary>
        /// Date of the Leave
        /// </summary>
        public DateTime FechaPermiso { get; set; }
    }
}
