using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioAPI.Infraestructura.Database.Entidades
{
    [Table("proveedor")]
    public class ProveedorEntity
    {
        [Key]
        public int id_proveedor {  get; set; }
        public string nombre_proveedor { get; set; }
        public string nombre_empresa { get; set; }
        public string email { get; set; }
        public string ciudad { get; set; }
        public string direccion { get; set; }
    }
}
