using System;
using System.ComponentModel.DataAnnotations;

namespace Compras.Models.Entities
{
    public class AsientoContableView
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public List<AsientoContable> AsientosContables { get; set; } = new List<AsientoContable>();
    }
}
