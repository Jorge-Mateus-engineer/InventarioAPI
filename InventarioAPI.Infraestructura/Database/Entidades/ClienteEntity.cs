using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventarioAPI.Infraestructura.Database.Entidades
{
    [Table("cliente")]
    public class ClienteEntity
    {
        [Key]
        public int id_cliente { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string contraseña_encriptada { get; set; }
        public byte[] salt { get; set; }
    }
}
