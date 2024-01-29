namespace InventarioAPI.Comunes.Clases.Contratos
{
    public class ClienteContract
    {
        public int id_cliente { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string correo { get; set; }
        public string? contrasena {  get; set; }
        public string telefono { get; set; }
    }
}
