using Microsoft.EntityFrameworkCore;
using ProyectoFinalCarRental.Data;
using ProyectoFinalCarRental.Models;
using System.Linq.Expressions;

namespace ProyectoFinalCarRental.Services
{
    public class EstadosReservaService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public EstadosReservaService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> Existe(int estadoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.EstadosReserva.AnyAsync(e => e.EstadoId == estadoId);
        }

        private async Task<bool> Insertar(EstadosReserva estado)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.EstadosReserva.Add(estado);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(EstadosReserva estado)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.EstadosReserva.Update(estado);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(EstadosReserva estado)
        {
            if (!await Existe(estado.EstadoId))
            {
                return await Insertar(estado);
            }
            else
            {
                return await Modificar(estado);
            }
        }

        public async Task<bool> Eliminar(int estadoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.EstadosReserva
                .AsNoTracking()
                .Where(e => e.EstadoId == estadoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<EstadosReserva?> Buscar(int estadoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.EstadosReserva
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.EstadoId == estadoId);
        }

        public async Task<List<EstadosReserva>> Listar(Expression<Func<EstadosReserva, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.EstadosReserva
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
