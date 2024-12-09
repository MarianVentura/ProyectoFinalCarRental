using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalCarRental.Models
{
    public class ReservaDetalle
    {
        [Key]
        public int ReservaDetalleId { get; set; }

        [Required(ErrorMessage = "La reserva es obligatoria.")]
        [ForeignKey("Reserva")]
        public int ReservaId { get; set; }
        public Reservas? Reserva { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        [ForeignKey("MetodoPago")]
        public int MetodoPagoId { get; set; }
        public MetodosPago? MetodoPago { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
        public decimal Monto { get; set; }  

        public string? Comentarios { get; set; }

        // Detalles para tarjeta de crédito/débito
        public string? NumeroTarjeta { get; set; }

        [StringLength(100, ErrorMessage = "El nombre del titular de la tarjeta no puede superar los 100 caracteres.")]
        public string? TitularTarjeta { get; set; }  // Nombre del titular de la tarjeta

        public DateTime? FechaVencimiento { get; set; }

        [StringLength(50, ErrorMessage = "El tipo de tarjeta no puede superar los 50 caracteres.")]
        public string? TipoTarjeta { get; set; }  // Ej. VISA, MasterCard, etc.

        [StringLength(4, ErrorMessage = "El código de seguridad debe tener 3 o 4 dígitos.")]
        public string? CodigoSeguridad { get; set; }  // CVV

        // Detalles para transferencia bancaria
        [StringLength(100, ErrorMessage = "El nombre del banco no puede superar los 100 caracteres.")]
        public string? BancoTransferencia { get; set; }  // Banco de la transferencia

        [StringLength(50, ErrorMessage = "El número de transferencia no puede superar los 50 caracteres.")]
        public string? NumeroTransferencia { get; set; }

        public DateTime? FechaTransferencia { get; set; }

        [StringLength(100, ErrorMessage = "El nombre del titular de la transferencia no puede superar los 100 caracteres.")]
        public string? NombreTitularTransferencia { get; set; }  // Titular de la cuenta de la transferencia
    }
}
