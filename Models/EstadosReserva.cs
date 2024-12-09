using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalCarRental.Models
{
    public class EstadosReserva
    {
        [Key]
        public int EstadoId { get; set; }
        
        public string? Nombre { get; set; }
    }
}
