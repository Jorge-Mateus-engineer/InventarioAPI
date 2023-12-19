using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioAPI.Infraestructura.Database.Entidades
{
    [Table("producto")]
    public class ProductoEntity
    {
        [Key]
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_categoria { get; set; }
        public string unidad {  get; set; }
        public float valor_unitario { get; set; }
        public int id_proveedor { get; set; }

    }
}
