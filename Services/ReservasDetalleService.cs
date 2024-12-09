using Microsoft.EntityFrameworkCore;
using ProyectoFinalCarRental.Data;
using ProyectoFinalCarRental.Models;
using System.Linq.Expressions;

namespace ProyectoFinalCarRental.Services
{
    public class ReservasDetalleService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public ReservasDetalleService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        private async Task<bool> ExisteReservaDetalle(int reservaDetalleId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.ReservaDetalles.AnyAsync(rd => rd.ReservaDetalleId == reservaDetalleId);
        }

        private async Task<bool> InsertarReservaDetalle(ReservaDetalle reservaDetalle)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.ReservaDetalles.Add(reservaDetalle);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> ModificarReservaDetalle(ReservaDetalle reservaDetalle)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(reservaDetalle);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> GuardarReservaDetalle(ReservaDetalle reservaDetalle)
        {
            if (await ExisteReservaDetalle(reservaDetalle.ReservaDetalleId))
            {
                return await ModificarReservaDetalle(reservaDetalle);
            }
            else
            {
                return await InsertarReservaDetalle(reservaDetalle);
            }
        }

        public async Task<bool> EliminarReservaDetalle(int reservaDetalleId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            var reservaDetalle = await contexto.ReservaDetalles
                .AsNoTracking()
                .FirstOrDefaultAsync(rd => rd.ReservaDetalleId == reservaDetalleId);
            if (reservaDetalle == null)
                return false;

            contexto.ReservaDetalles.Remove(reservaDetalle);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<ReservaDetalle?> ObtenerReservaDetallePorId(int reservaDetalleId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.ReservaDetalles
                .Include(rd => rd.Reserva)  // Incluir Reserva
                .Include(rd => rd.MetodoPago)  // Incluir MetodoPago
                .AsNoTracking()
                .FirstOrDefaultAsync(rd => rd.ReservaDetalleId == reservaDetalleId);
        }

        public async Task<List<ReservaDetalle>> ObtenerReservaDetalles(Expression<Func<ReservaDetalle, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.ReservaDetalles
                .Include(rd => rd.Reserva)  // Incluir Reserva
                .Include(rd => rd.MetodoPago)  // Incluir MetodoPago
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<List<ReservaDetalle>> ObtenerReservaDetallesPorReserva(int reservaId)
        {
            return await ObtenerReservaDetalles(rd => rd.ReservaId == reservaId);
        }

        public async Task<List<ReservaDetalle>> ObtenerReservaDetallesPorMetodo(int metodoPagoId)
        {
            return await ObtenerReservaDetalles(rd => rd.MetodoPagoId == metodoPagoId);
        }
    }
}
