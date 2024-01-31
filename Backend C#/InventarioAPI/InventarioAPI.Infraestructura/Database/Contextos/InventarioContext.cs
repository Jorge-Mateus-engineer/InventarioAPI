﻿using InventarioAPI.Infraestructura.Database.Entidades;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Infraestructura.Database.Contextos
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) { }

        #region [DBSets]
        public virtual DbSet<BodegaEntity> Bodegas { get; set; }
        public virtual DbSet<CategoriaEntity> Categorias { get; set; }
        public virtual DbSet<ClienteEntity> Clientes { get; set; }
        public virtual DbSet<CompraEntity> Compras { get; set; }
        public virtual DbSet<DetalleCompraEntity> DetalleCompras { get; set; }
        public virtual DbSet<DisponibilidadEntity> Disponibilidades { get; set; }
        public virtual DbSet<ProductoEntity> Productos { get; set; }
        public virtual DbSet<ProveedorEntity> Proveedores { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Resolve type issue caused by the decimal(30,2) type in the DB and
            //using a float type on the front end
            modelBuilder.Entity<CompraEntity>()
                .Property(c => c.valor_total)
                .HasColumnType("decimal(30, 2)");
            // Configure the keyless entity
            modelBuilder.Entity<DisponibilidadEntity>().HasNoKey();
        }
    }
}
