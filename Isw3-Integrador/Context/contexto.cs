using Isw3_Integrador.Models;
using Microsoft.EntityFrameworkCore;

namespace Isw3_Integrador.Context
{
    public class contexto : DbContext
    {
        public contexto(DbContextOptions<contexto> options) : base(options)
        {
        }

        public DbSet<Alumno> Alumno { get; set; }
    }
    
}
