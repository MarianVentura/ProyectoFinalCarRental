using Microsoft.EntityFrameworkCore;
using ProyectoFinalCarRental.Data;
using ProyectoFinalCarRental.Models;
using System.Linq.Expressions;

namespace ProyectoFinalCarRental.Services
{
    public class MantenimientoVehiculoService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public MantenimientoVehiculoService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        // Verificar si el mantenimiento existe por su ID
        public async Task<bool> Existe(int mantenimientoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MantenimientoVehiculos.AnyAsync(mv => mv.MantenimientoId == mantenimientoId);
        }

        // Insertar un nuevo mantenimiento
        private async Task<bool> Insertar(MantenimientoVehiculo mantenimiento)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.MantenimientoVehiculos.Add(mantenimiento);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Modificar un mantenimiento existente
        private async Task<bool> Modificar(MantenimientoVehiculo mantenimiento)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(mantenimiento);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Guardar (Insertar o Modificar) el mantenimiento
        public async Task<bool> Guardar(MantenimientoVehiculo mantenimiento)
        {
            if (!await Existe(mantenimiento.MantenimientoId))
            {
                return await Insertar(mantenimiento);
            }
            else
            {
                return await Modificar(mantenimiento);
            }
        }

        // Eliminar un mantenimiento por ID
        public async Task<bool> Eliminar(int mantenimientoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MantenimientoVehiculos
                .AsNoTracking()
                .Where(mv => mv.MantenimientoId == mantenimientoId)
                .ExecuteDeleteAsync() > 0;
        }

        // Buscar un mantenimiento por su ID
        public async Task<MantenimientoVehiculo?> Buscar(int mantenimientoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MantenimientoVehiculos
                .Include(mv => mv.Vehiculo)
                .AsNoTracking()
                .FirstOrDefaultAsync(mv => mv.MantenimientoId == mantenimientoId);
        }

        // Buscar mantenimientos por VehiculoId
        public async Task<List<MantenimientoVehiculo>> BuscarPorVehiculo(int vehiculoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MantenimientoVehiculos
                .Where(mv => mv.VehiculoId == vehiculoId)
                .Include(mv => mv.Vehiculo)
                .AsNoTracking()
                .ToListAsync();
        }

        // Listar todos los mantenimientos
        public async Task<List<MantenimientoVehiculo>> Listar(Expression<Func<MantenimientoVehiculo, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MantenimientoVehiculos
                .Include(mv => mv.Vehiculo)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        // Obtener los mantenimientos recientes (por ejemplo, los últimos 10)
        public async Task<List<MantenimientoVehiculo>> ObtenerMantenimientosRecientes(int cantidad = 10)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.MantenimientoVehiculos
                .OrderByDescending(mv => mv.FechaMantenimiento)
                .Take(cantidad)
                .Include(mv => mv.Vehiculo)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
