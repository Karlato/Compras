using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Compras.Models.Entities
{
    public class Proveedor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Cédula o RNC")]
        public string Cedula_RNC { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre Comercial")]
        public string NombreComercial { get; set; }

        [Required]
        [StringLength(10)]
        public string Estado { get; set; }
    }
}
