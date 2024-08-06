using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Compras.Models.Entities
{
    public class Orden
    {
        [Key]
        [Display(Name = "Número de Orden")]
        public int NumeroOrden { get; set; }

        [Required]
        [Display(Name = "Fecha de Orden")]
        public DateTime FechaOrden { get; set; }

        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        [Required]
        public int ArticuloID { get; set; }

        [ForeignKey("ArticuloID")]
        [Display(Name = "Artículo")]
        public Articulo? Articulo { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser menor a 0.")]
        public int Cantidad { get; set; }

        public int? MedidaID { get; set; }

        [ForeignKey("MedidaID")]
        [Display(Name = "Unidad de Medida")]
        public UnidadMedida? UnidadMedida { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        [Range(0.00, double.MaxValue, ErrorMessage = "El costo unitario no puede ser menor a 0.")]
        [Display(Name = "Costo Unitario")]
        public decimal CostoUnitario { get; set; }
    }
}
