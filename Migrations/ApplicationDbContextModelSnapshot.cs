﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinalCarRental.Data;

#nullable disable

namespace ProyectoFinalCarRental.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoIdentificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.EstadosReserva", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("EstadosReserva");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Nombre = "Pendiente"
                        },
                        new
                        {
                            EstadoId = 2,
                            Nombre = "Confirmada"
                        },
                        new
                        {
                            EstadoId = 3,
                            Nombre = "Cancelada"
                        });
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.MantenimientoVehiculo", b =>
                {
                    b.Property<int>("MantenimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MantenimientoId"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaMantenimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("MantenimientoId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("MantenimientoVehiculos");
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.MetodosPago", b =>
                {
                    b.Property<int>("MetodoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetodoPagoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MetodoPagoId");

                    b.ToTable("MetodosPago");

                    b.HasData(
                        new
                        {
                            MetodoPagoId = 1,
                            Nombre = "Tarjeta"
                        },
                        new
                        {
                            MetodoPagoId = 2,
                            Nombre = "Transferencia Bancaria"
                        });
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.ReservaDetalle", b =>
                {
                    b.Property<int>("ReservaDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaDetalleId"));

                    b.Property<string>("BancoTransferencia")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CodigoSeguridad")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaTransferencia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("MetodoPagoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NombreTitularTransferencia")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumeroTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTransferencia")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.Property<string>("TipoTarjeta")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TitularTarjeta")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ReservaDetalleId");

                    b.HasIndex("MetodoPagoId");

                    b.HasIndex("ReservaId");

                    b.ToTable("ReservaDetalles");
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.Reservas", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDevolucion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRecogida")
                        .HasColumnType("datetime2");

                    b.Property<int>("MetodoPagoId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrecio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("MetodoPagoId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.Vehiculo", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehiculoId"));

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Combustible")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponible")
                        .HasColumnType("bit");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioPorDia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoTransmision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehiculoId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProyectoFinalCarRental.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProyectoFinalCarRental.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinalCarRental.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProyectoFinalCarRental.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.MantenimientoVehiculo", b =>
                {
                    b.HasOne("ProyectoFinalCarRental.Models.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.ReservaDetalle", b =>
                {
                    b.HasOne("ProyectoFinalCarRental.Models.MetodosPago", "MetodoPago")
                        .WithMany()
                        .HasForeignKey("MetodoPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinalCarRental.Models.Reservas", "Reserva")
                        .WithMany("ReservaDetalles")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MetodoPago");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.Reservas", b =>
                {
                    b.HasOne("ProyectoFinalCarRental.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoFinalCarRental.Models.EstadosReserva", "EstadosReserva")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoFinalCarRental.Models.MetodosPago", "MetodosPago")
                        .WithMany()
                        .HasForeignKey("MetodoPagoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectoFinalCarRental.Models.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("EstadosReserva");

                    b.Navigation("MetodosPago");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("ProyectoFinalCarRental.Models.Reservas", b =>
                {
                    b.Navigation("ReservaDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
