using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalCarRental.Models;

namespace ProyectoFinalCarRental.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Reservas> Reservas { get; set; }
    public DbSet<MetodosPago> MetodosPago { get; set; }
    public DbSet<MantenimientoVehiculo> MantenimientoVehiculos { get; set; }
    public DbSet<EstadosReserva> EstadosReserva { get; set; }
    public DbSet<ReservaDetalle> ReservaDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Relación Reservas -> Cliente
        modelBuilder.Entity<Reservas>()
            .HasOne(r => r.Cliente)
            .WithMany()
            .HasForeignKey(r => r.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Reservas -> Vehiculo
        modelBuilder.Entity<Reservas>()
            .HasOne(r => r.Vehiculo)
            .WithMany()
            .HasForeignKey(r => r.VehiculoId)
            .OnDelete(DeleteBehavior.Restrict);


        // Relación EstadosReserva -> Reservas
        modelBuilder.Entity<EstadosReserva>()
              .HasMany<Reservas>()
              .WithOne(r => r.EstadosReserva)
              .HasForeignKey(r => r.EstadoId)
              .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EstadosReserva>().HasData(
            new EstadosReserva { EstadoId = 1, Nombre = "Pendiente" },
            new EstadosReserva { EstadoId = 2, Nombre = "Confirmada" },
            new EstadosReserva { EstadoId = 3, Nombre = "Cancelada" }
            );

        modelBuilder.Entity<MetodosPago>()
               .HasMany<Reservas>()
               .WithOne(r => r.MetodosPago)
               .HasForeignKey(r => r.MetodoPagoId)
               .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MetodosPago>().HasData(
            new MetodosPago { MetodoPagoId = 1, Nombre = "Tarjeta" },
            new MetodosPago { MetodoPagoId = 2, Nombre = "Transferencia Bancaria" }
            );


        modelBuilder.Entity<ReservaDetalle>()
            .HasOne(rd => rd.Reserva)
            .WithMany(r => r.ReservaDetalles)
            .HasForeignKey(rd => rd.ReservaId)
            .OnDelete(DeleteBehavior.Cascade);  

        modelBuilder.Entity<ReservaDetalle>()
            .HasOne(rd => rd.MetodoPago)
            .WithMany()  
            .HasForeignKey(rd => rd.MetodoPagoId);


        modelBuilder.Entity<MantenimientoVehiculo>()
            .HasOne(mv => mv.Vehiculo)
            .WithMany()
            .HasForeignKey(mv => mv.VehiculoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MantenimientoVehiculo>()
            .Property(m => m.Costo)
            .HasColumnType("decimal(18,2)");  

        modelBuilder.Entity<Reservas>()
            .Property(r => r.TotalPrecio)
            .HasColumnType("decimal(18,2)");  

        modelBuilder.Entity<Vehiculo>()
            .Property(v => v.PrecioPorDia)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ReservaDetalle>()
        .Property(r => r.Monto)
        .HasColumnType("decimal(18,2)");
    }
}
