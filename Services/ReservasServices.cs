using Microsoft.EntityFrameworkCore;
using ProyectoFinalCarRental.Data;
using ProyectoFinalCarRental.Models;
using System.Linq.Expressions;

namespace ProyectoFinalCarRental.Services
{
    public class ReservasService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public ReservasService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        private async Task<bool> ExisteReserva(int reservaId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Reservas.AnyAsync(r => r.ReservaId == reservaId);
        }

        private async Task<bool> InsertarReserva(Reservas reserva)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Reservas.Add(reserva);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> ModificarReserva(Reservas reserva)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(reserva);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> GuardarReserva(Reservas reserva)
        {
            if (await ExisteReserva(reserva.ReservaId))
            {
                return await ModificarReserva(reserva);
            }
            else
            {
                return await InsertarReserva(reserva);
            }
        }

        public async Task<bool> EliminarReserva(int reservaId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            var reserva = await contexto.Reservas
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ReservaId == reservaId);
            if (reserva == null)
                return false;

            contexto.Reservas.Remove(reserva);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Reservas?> ObtenerReservaPorId(int reservaId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Vehiculo)
                .Include(r => r.EstadosReserva)
                .Include(r => r.MetodosPago)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ReservaId == reservaId);
        }

        public async Task<List<Reservas>> ObtenerReservas(Expression<Func<Reservas, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Vehiculo)
                .Include(r => r.EstadosReserva)
                .Include(r => r.MetodosPago)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<List<Reservas>> ObtenerReservasConfirmadas()
        {
            return await ObtenerReservas(r => r.EstadosReserva.Nombre == "Confirmada");
        }

        public async Task<List<Reservas>> ObtenerReservasPendientes()
        {
            return await ObtenerReservas(r => r.EstadosReserva.Nombre == "Pendiente");
        } 
        public async Task<List<Reservas>> ObtenerReservasCanceladas()
        {
            return await ObtenerReservas(r => r.EstadosReserva.Nombre == "Cancelada");
        }

        public async Task<List<Reservas>> BuscarReservasPorCliente(int clienteId)
        {
            return await ObtenerReservas(r => r.ClienteId == clienteId);
        }

        public async Task<bool> CambiarEstadoReserva(int reservaId, int nuevoEstadoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            var reserva = await contexto.Reservas
                .FirstOrDefaultAsync(r => r.ReservaId == reservaId);
            if (reserva == null)
                return false;

            reserva.EstadoId = nuevoEstadoId;
            contexto.Reservas.Update(reserva);
            return await contexto.SaveChangesAsync() > 0;
        }
    }
}
