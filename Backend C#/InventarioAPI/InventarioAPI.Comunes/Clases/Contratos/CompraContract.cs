namespace InventarioAPI.Comunes.Clases.Contratos
{
    public class CompraContract
    {
        public int id_compra { get; set; }
        public int id_cliente { get; set; }
        public DateTime hora_de_compra { get; set; }
        public decimal valor_total { get; set; }
    }
}
