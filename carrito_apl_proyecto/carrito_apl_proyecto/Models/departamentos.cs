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
    
    public partial class departamentos
    {
        public departamentos()
        {
            this.ciudades = new HashSet<ciudades>();
        }
    
        public int pk_departamento { get; set; }
        public int fk_pais { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<ciudades> ciudades { get; set; }
        public virtual paises paises { get; set; }
    }
}
