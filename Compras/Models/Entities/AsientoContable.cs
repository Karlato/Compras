using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Compras.Models.Entities
{
    public class AsientoContable
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(255)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Identificador Auxiliar")]
        public string? IdAuxiliar { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Cuenta DB")]
        public string? Cuenta_DB { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Cuenta CR")]
        public string? Cuenta_CR { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
    }
}
