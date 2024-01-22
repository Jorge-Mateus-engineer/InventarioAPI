using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioAPI.Infraestructura.Database.Entidades
{
    [Table("disponibilidad")]
    public class DisponibilidadEntity
    {
        public int id_producto {  get; set; }
        public int id_bodega {  get; set; }
        public string unidad { get; set; }
        public int unidades_disponibles { get; set; }
    }
}
