using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventarioAPI.Infraestructura.Database.Entidades
{
    [Table("categoria")]
    public class CategoriaEntity
    {
        [Key]
        public int id_categoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
     
    }
}
