using Hackaton.API.Data;
using Hackaton.shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Veterinary.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckRolesAsync();
            await CheckStatusesAsync();
        }

        private async Task CheckRolesAsync()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.Add(new Rol { rol = "Desarrollador" });
                _context.Roles.Add(new Rol { rol = "Lider de equipo" });
                _context.Roles.Add(new Rol { rol = "Diseñador" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckStatusesAsync()
        {
            if (!_context.Status.Any())
            {
                // Agregar valores por defecto a la tabla Status
                _context.Status.Add(new Status { status = "Diseño" });
                _context.Status.Add(new Status { status = "En progreso" });
                _context.Status.Add(new Status { status = "Finalizado" });
                _context.Status.Add(new Status { status = "Entregado" });
                _context.Status.Add(new Status { status = "Calificado" });

                await _context.SaveChangesAsync();
            }
        }
    }
}