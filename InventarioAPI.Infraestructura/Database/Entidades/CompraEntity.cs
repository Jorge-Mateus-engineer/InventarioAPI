using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioAPI.Infraestructura.Database.Entidades
{
    [Table("compra")]
    public class CompraEntity
    {
        [Key]
        public int id_compra { get; set; }
        public int id_cliente { get; set; }
        public DateTime hora_de_compra { get; set; }
        public float valor_total { get; set; }

    }
}
