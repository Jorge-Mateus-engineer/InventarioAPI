using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioAPI.Infraestructura.Database.Entidades
{
    [Table("detalle_compra")]
    public class DetalleCompraEntity
    {
        [Key]
        public int id_detalle_compra { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public float total_detalle { get; set; }
        public int id_compra { get; set; }
    }
}
