﻿using Microsoft.EntityFrameworkCore;
using ProyectoFinalCarRental.Data;
using ProyectoFinalCarRental.Models;
using System.Linq.Expressions;

namespace ProyectoFinalCarRental.Services
{
    public class VehiculosService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public VehiculosService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        // Verificar si existe un vehículo por ID
        public async Task<bool> Existe(int vehiculoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos.AnyAsync(v => v.VehiculoId == vehiculoId);
        }

        // Insertar un nuevo vehículo
        private async Task<bool> Insertar(Vehiculo vehiculo)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Vehiculos.Add(vehiculo);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Modificar un vehículo existente
        private async Task<bool> Modificar(Vehiculo vehiculo)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(vehiculo);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Guardar un vehículo (insertar o modificar)
        public async Task<bool> Guardar(Vehiculo vehiculo)
        {
            if (!await Existe(vehiculo.VehiculoId))
            {
                return await Insertar(vehiculo);
            }
            else
            {
                return await Modificar(vehiculo);
            }
        }

        // Eliminar un vehículo
        public async Task<bool> Eliminar(Vehiculo vehiculo)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos
                .AsNoTracking()
                .Where(v => v.VehiculoId == vehiculo.VehiculoId)
                .ExecuteDeleteAsync() > 0;
        }

        // Buscar un vehículo por ID
        public async Task<Vehiculo?> Buscar(int vehiculoId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.VehiculoId == vehiculoId);
        }

        // Buscar vehículos por marca
        public async Task<List<Vehiculo>> BuscarPorMarca(string marca)
        {
            if (string.IsNullOrWhiteSpace(marca))
            {
                return new List<Vehiculo>();
            }

            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos
                .Where(v => v.Marca.Contains(marca))
                .AsNoTracking()
                .ToListAsync();
        }

        // Listar vehículos con un criterio específico
        public async Task<List<Vehiculo>> Listar(Expression<Func<Vehiculo, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        // Obtener todos los vehículos
        public async Task<List<Vehiculo>> ObtenerVehiculos()
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Vehiculos
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
