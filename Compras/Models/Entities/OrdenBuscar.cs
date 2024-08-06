namespace Compras.Models.Entities
{
    public class OrdenBuscar
    {
        public int? NumeroOrden { get; set; }
        public DateTime? FechaOrden { get; set; }
        public string Articulo { get; set; }
        public IEnumerable<Orden> Ordenes { get; set; }
    }
}
