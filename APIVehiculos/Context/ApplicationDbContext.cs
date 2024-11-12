

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Vehiculo>(entity =>
        {
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculo");

            entity.Property(v => v.Marca).IsRequired();
            entity.Property(v => v.Modelo).IsRequired();
            entity.Property(v => v.PrecioPorDia).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(v => v.EstaDisponible).IsRequired();
        });

        modelBuilder.Entity<Reserva>(entity =>
            {
                modelBuilder.Entity<Reserva>().ToTable("Rerserva");
                entity.Property(r => r.Estado).IsRequired();
                entity.HasOne(r => r.Vehiculo).WithMany(v => v.Reservas).HasForeignKey(r => r.VehiculoId);//.OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.Usuario).WithMany(u => u.Reservas).HasForeignKey(r => r.UsuarioId);//Delete(DeleteBehavior.Cascade);
                // Restricción de fecha para evitar reservas en fechas pasadas
                entity.ToTable(t => t.HasCheckConstraint("CK_Reserva_Fecha", "FechaInicio >= GETDATE()"));

            });
    }
}