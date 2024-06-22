using AppNetRazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Poner aqui los modelos
        public DbSet<Curso> Curso { get; set; }
    }
}
