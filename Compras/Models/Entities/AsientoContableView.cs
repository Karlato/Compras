using System;
using System.ComponentModel.DataAnnotations;

namespace Compras.Models.Entities
{
    public class AsientoContableView
    {
        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public int IdCuenta { get; set; }
        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int CuentaDB { get; set; }

        [Required]
        public int CuentaCR { get; set; }
        [Required]
        public double Monto { get; set; }
    }
}
