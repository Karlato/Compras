using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Compras.Models.Entities
{
    public class Articulo
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Required]
        public int MedidaID { get; set; }

        [ForeignKey("MedidaID")]
        [Display(Name = "Unidad de Medida")]
        public UnidadMedida? UnidadMedida { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La existencia no puede ser menor a 0.")]
        public int Existencia { get; set; }

        [Required]
        [StringLength(10)]
        public string Estado { get; set; }
    }
}
