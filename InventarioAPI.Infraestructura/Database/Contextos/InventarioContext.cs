using InventarioAPI.Infraestructura.Database.Entidades;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPI.Infraestructura.Database.Contextos
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) { }

        #region [DBSets]
        public virtual DbSet<BodegaEntity> Bodegas {  get; set; }
        public virtual DbSet<CategoriaEntity> Categorias {  get; set; }
        public virtual DbSet<ClienteEntity> Clientes {  get; set; }
        public virtual DbSet<CompraEntity> Compras {  get; set; }
        public virtual DbSet<DetalleCompraEntity> DetalleCompras {  get; set; }
        public virtual DbSet<DisponibilidadEntity> Disponibilidades {  get; set; }
        public virtual DbSet<ProductoEntity> Productos {  get; set; }
        public virtual DbSet<ProveedorEntity> Proveedores {  get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
