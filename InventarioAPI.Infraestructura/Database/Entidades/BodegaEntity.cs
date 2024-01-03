using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventarioAPI.Infraestructura.Database.Entidades
{
    [Table("bodega")]
    public class BodegaEntity
    {
        [Key]
        public int id_bodega {  get; set; }
        public string nombre { get; set; }
        public TimeSpan hora_de_apertura { get; set; }
        public TimeSpan hora_de_cierre { get; set; }
        public string direccion {  get; set; }
    }
}
