using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalCarRental.Models;

public class Reservas
{
    [Key]
    public int ReservaId { get; set; }

    [Required(ErrorMessage = "El cliente es obligatorio.")]
    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }


    [Required(ErrorMessage = "El vehículo es obligatorio.")]
    [ForeignKey("Vehiculo")]
    public int VehiculoId { get; set; }
    public Vehiculo? Vehiculo { get; set; }

    [Required(ErrorMessage = "La fecha de recogida es obligatoria.")]
    public DateTime FechaRecogida { get; set; }

    [Required(ErrorMessage = "La fecha de devolución es obligatoria.")]
    public DateTime FechaDevolucion { get; set; }

    [Required(ErrorMessage = "El precio total es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio total debe ser un valor positivo.")]
    public decimal TotalPrecio { get; set; }

    [ForeignKey("EstadosReserva")]
    public int EstadoId { get; set; }
    public EstadosReserva? EstadosReserva { get; set; }

    [ForeignKey("MetodosPago")]
    public int MetodoPagoId { get; set; }

    public MetodosPago? MetodosPago { get; set; }
}
