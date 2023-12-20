namespace InventarioAPI.Comunes.Clases.Contratos
{
    public class DisponibilidadContract
    {
        public int id_producto { get; set; }
        public int id_bodega { get; set; }
        public string unidad { get; set; }
        public int unidades_disponibles { get; set; }
    }
}
