using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Compras.Models.Entities
{
    public class AsientoContable
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "IdAuxiliar")]
        public int? IdAuxiliarOrigen { get; set; }
        [Required]
        [Display(Name = "IdCuenta")]
        public int IdCuenta { get; set; }
        [Required]
        [MaxLength(255)]
        public string Descripcion { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "El valor de {0} debe ser 0 o 1.")]
        [Display(Name = "Cuenta DB")]
        public int? CuentaDB { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "El valor de {0} debe ser 0 o 1.")]
        [Display(Name = "Cuenta CR")]
        public int? CuentaCR { get; set; }
        [Required]
        [Column(TypeName = "float")]
        [Display(Name = "Monto")]
        public double Monto { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Fecha")]
        public DateTime? Fecha { get; set; }
        public string? Estado { get; set; }

        [NotMapped]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [NotMapped]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
    }
}
