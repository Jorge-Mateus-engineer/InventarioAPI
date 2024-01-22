namespace InventarioAPI.Comunes.Clases.Contratos
{
    public class ProveedorContract
    {
        public int id_proveedor { get; set; }
        public string nombre_proveedor { get; set; }
        public string nombre_empresa { get; set; }
        public string email { get; set; }
        public string ciudad { get; set; }
        public string direccion { get; set; }
    }
}
