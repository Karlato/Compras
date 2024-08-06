using Compras.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Compras.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<UnidadMedida> UnidadesMedida { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<AsientoContable> AsientosContables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.UnidadMedida)
                .WithMany()
                .HasForeignKey(a => a.MedidaID);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Articulo)
                .WithMany()
                .HasForeignKey(o => o.ArticuloID);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.UnidadMedida)
                .WithMany()
                .HasForeignKey(o => o.MedidaID);

            modelBuilder.Entity<Orden>()
                .Property(o => o.CostoUnitario)
                .HasColumnType("decimal(12, 2)");

            modelBuilder.Entity<AsientoContable>()
                .Property(a => a.Fecha)
                .HasColumnType("datetime");

            modelBuilder.Entity<AsientoContable>()
                .Property(a => a.Monto)
                .HasColumnType("float");

            base.OnModelCreating(modelBuilder);
        }

        public async Task RealizarOrdenAsync(DateTime fechaOrden, int articuloId, int cantidad, string estado, decimal costoUnitario)
        {
            var medidaIdParam = new SqlParameter("@MedidaID", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var numeroOrdenParam = new SqlParameter("@NumeroOrden", SqlDbType.Int) { Direction = ParameterDirection.Output };

            await Database.ExecuteSqlRawAsync(
                "EXEC RealizarOrden @FechaOrden, @ArticuloID, @Cantidad, @Estado, @MedidaID OUTPUT, @NumeroOrden OUTPUT, @CostoUnitario",
                new SqlParameter("@FechaOrden", fechaOrden),
                new SqlParameter("@ArticuloID", articuloId),
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@Estado", estado),
                medidaIdParam,
                numeroOrdenParam,
                new SqlParameter("@CostoUnitario", costoUnitario)
            );

            int medidaId = (int)medidaIdParam.Value;
            int numeroOrden = (int)numeroOrdenParam.Value;
        }

        public async Task ActualizarOrdenAsync(int numeroOrden, DateTime fechaOrden, int articuloId, int cantidad, string estado, decimal costoUnitario)
        {
            var medidaIdParam = new SqlParameter("@MedidaID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            await Database.ExecuteSqlRawAsync(
                "EXEC ActualizarOrden @NumeroOrden, @FechaOrden, @ArticuloID, @Cantidad, @Estado, @MedidaID OUTPUT, @CostoUnitario",
                new SqlParameter("@NumeroOrden", numeroOrden),
                new SqlParameter("@FechaOrden", fechaOrden),
                new SqlParameter("@ArticuloID", articuloId),
                new SqlParameter("@Cantidad", cantidad),
                new SqlParameter("@Estado", estado),
                medidaIdParam,
                new SqlParameter("@CostoUnitario", costoUnitario)
            );

            int medidaId = (int)medidaIdParam.Value;
        }

        public async Task DisponibilidadArticulosAsync()
        {
            await Database.ExecuteSqlRawAsync("EXEC DisponibilidadArticulos");
        }

        public async Task RevertirOrdenAsync(int numeroOrden)
        {
            await Database.ExecuteSqlRawAsync("EXEC RevertirOrden @p0", numeroOrden);
        }
    }
}
