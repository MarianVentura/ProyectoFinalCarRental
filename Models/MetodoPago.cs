using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalCarRental.Models;

public class MetodosPago
{
    [Key]
    public int MetodoPagoId { get; set; }

    [Required(ErrorMessage = "No puede estar Vacio")]
    public string? Nombre { get; set; }
}
