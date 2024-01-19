namespace InventarioAPI.Comunes.Clases.Contratos
{
    public class ProductoContract
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_categoria { get; set; }
        public string unidad { get; set; }
        public float precio_unitario { get; set; }
        public int id_proveedor { get; set; }
    }
}
