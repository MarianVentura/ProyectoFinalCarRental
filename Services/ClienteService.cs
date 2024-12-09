using Microsoft.EntityFrameworkCore;
using ProyectoFinalCarRental.Data;
using ProyectoFinalCarRental.Models;
using System.Linq.Expressions;

namespace ProyectoFinalCarRental.Services
{
    public class ClienteService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public ClienteService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        // Verificar si existe un cliente por ID
        public async Task<bool> Existe(int clienteId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes.AnyAsync(c => c.ClienteId == clienteId);
        }

        // Insertar un nuevo cliente
        private async Task<bool> Insertar(Cliente cliente)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Clientes.Add(cliente);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Modificar un cliente existente
        private async Task<bool> Modificar(Cliente cliente)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(cliente);
            return await contexto.SaveChangesAsync() > 0;
        }

        // Guardar cliente (insertar o modificar)
        public async Task<bool> Guardar(Cliente cliente)
        {
            if (!await Existe(cliente.ClienteId))
            {
                return await Insertar(cliente);
            }
            else
            {
                return await Modificar(cliente);
            }
        }

        // Eliminar un cliente
        public async Task<bool> Eliminar(Cliente cliente)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AsNoTracking()
                .Where(c => c.ClienteId == cliente.ClienteId)
                .ExecuteDeleteAsync() > 0;
        }

        // Buscar un cliente por ID
        public async Task<Cliente?> Buscar(int clienteId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }

        // Buscar cliente por nombre
        public async Task<List<Cliente>> BuscarPorNombre(string nombre)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .Where(c => c.Nombres.Contains(nombre))
                .AsNoTracking()
                .ToListAsync();
        }

        // Buscar cliente por tipo de identificación
        public async Task<List<Cliente>> BuscarPorTipoIdentificacion(string tipoIdentificacion)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .Where(c => c.TipoIdentificacion.ToLower() == tipoIdentificacion.ToLower())
                .AsNoTracking()
                .ToListAsync();
        }

        // Verificar si ya existe un cliente con la misma identificación
        public async Task<bool> ExisteClientePorIdentificacion(int clienteId, string identificacion)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AnyAsync(c => c.ClienteId != clienteId && c.Identificacion == identificacion);
        }

        // Obtener todos los clientes
        public async Task<List<Cliente>> ObtenerClientes()
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes.AsNoTracking().ToListAsync();
        }

        // Buscar un cliente por su identificación
        public async Task<Cliente?> BuscarPorIdentificacion(string identificacion)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Identificacion == identificacion);
        }


    }
}
