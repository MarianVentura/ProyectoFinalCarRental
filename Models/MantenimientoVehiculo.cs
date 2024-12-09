﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalCarRental.Models;

public class MantenimientoVehiculo
{
    [Key]
    public int MantenimientoId { get; set; }

    [Required(ErrorMessage = "El vehículo es obligatorio.")]
    [ForeignKey("Vehiculo")]
    public int VehiculoId { get; set; }
    public virtual Vehiculo? Vehiculo { get; set; }

    [Required(ErrorMessage = "La fecha de mantenimiento es obligatoria.")]
    public DateTime FechaMantenimiento { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El costo es obligatorio.")]
    public decimal Costo { get; set; }
}
