using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Compras.Models.Entities
{
    public class UnidadMedida
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(10)]
        public string Estado { get; set; }
    }
}
