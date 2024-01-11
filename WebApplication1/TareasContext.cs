using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;

namespace WebApplication1
{
    public class TareasContext : DbContext
    {
            
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> dbContext):base(dbContext) { }
 



        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Categoria>(c =>
            {
                c.ToTable("Categoria");
                c.HasKey(c => c.CategoriaId);
                c.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
                c.Property(c => c.Descripcion).IsRequired().HasMaxLength(150);
           });


            mb.Entity<Tarea>(t => {

                t.ToTable("Tarea");
                t.HasKey(t => t.TareaId);
                //t.HasOne(t => t.CategoriaId).
                //WithMany(t )
                t.HasOne(t => t.Categoria)
                    .WithMany(c => c.Tareas)
                    .HasForeignKey(t => t.CategoriaId);
                t.Property(t => t.Titulo).IsRequired().HasMaxLength(150);
                t.Property(t => t.Descripcion).IsRequired().HasMaxLength(150);
                t.Property(t => t.PrioridadTarea);
                t.Property(t => t.FechaCreacion);
                t.Ignore(t => t.Resumen);

            
            });
        }

    }
}
