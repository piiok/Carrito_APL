﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_carrito_apl_Entities : DbContext
    {
        public db_carrito_apl_Entities()
            : base("name=db_carrito_apl_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cargo_ciudades> cargo_ciudades { get; set; }
        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<ciudades> ciudades { get; set; }
        public virtual DbSet<compradores> compradores { get; set; }
        public virtual DbSet<departamentos> departamentos { get; set; }
        public virtual DbSet<direcciones> direcciones { get; set; }
        public virtual DbSet<especificaciones> especificaciones { get; set; }
        public virtual DbSet<facturas> facturas { get; set; }
        public virtual DbSet<items> items { get; set; }
        public virtual DbSet<paises> paises { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tarjetas> tarjetas { get; set; }
        public virtual DbSet<transportes> transportes { get; set; }
    }
}
