//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace carrito_apl_proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class especificaciones
    {
        public int pk_especificacion { get; set; }
        public int fk_producto { get; set; }
        public string descripcion { get; set; }
    
        public virtual productos productos { get; set; }
    }
}
