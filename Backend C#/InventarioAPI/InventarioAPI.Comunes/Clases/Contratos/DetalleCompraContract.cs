namespace InventarioAPI.Comunes.Clases.Contratos
{
    public class DetalleCompraContract
    {
        public int id_detalle_compra { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public float total_detalle { get; set; }
        public int id_compra { get; set; }
    }
}
