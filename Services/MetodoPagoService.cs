using Microsoft.EntityFrameworkCore;
using ProyectoFinalCarRental.Data;
using ProyectoFinalCarRental.Models;
using System.Linq.Expressions;

namespace ProyectoFinalCarRental.Services
{
    public class MetodosPagoService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public MetodosPagoService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> Existe(int metodoPagoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MetodosPago.AnyAsync(m => m.MetodoPagoId == metodoPagoId);
        }

        private async Task<bool> Insertar(MetodosPago metodoPago)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.MetodosPago.Add(metodoPago);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(MetodosPago metodoPago)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(metodoPago);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(MetodosPago metodoPago)
        {
            if (!await Existe(metodoPago.MetodoPagoId))
            {
                return await Insertar(metodoPago);
            }
            else
            {
                return await Modificar(metodoPago);
            }
        }

        public async Task<bool> Eliminar(MetodosPago metodoPago)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MetodosPago
                .AsNoTracking()
                .Where(m => m.MetodoPagoId == metodoPago.MetodoPagoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<MetodosPago?> Buscar(int metodoPagoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MetodosPago
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MetodoPagoId == metodoPagoId);
        }

        public async Task<List<MetodosPago>> Listar(Expression<Func<MetodosPago, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MetodosPago
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<List<MetodosPago>> ObtenerMetodosPago()
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MetodosPago.AsNoTracking().ToListAsync();
        }
    }
}
