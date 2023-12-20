namespace InventarioAPI.Comunes.Clases.Contratos
{
    public class BodegaContract
    {
        public int id_bodega { get; set; }
        public string nombre { get; set; }
        public TimeOnly hora_de_apertura { get; set; }
        public TimeOnly hora_de_cierre { get; set; }
        public string direccion { get; set; }
    }
}
