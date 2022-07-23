using Microsoft.EntityFrameworkCore;
using projectEF.Models;

namespace projectEF;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}

    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria()
        {
        CategoriaID = Guid.Parse("9a1747dc-c512-4c0e-80ea-9b1baffd716c"),
        Nombre = "Avtividades Pendientes",
        Peso = 50 
        });
        categoriasInit.Add(new Categoria()
        {
        CategoriaID = Guid.Parse("9a1747dc-c512-4c0e-80ea-9b1baffd7152"),
        Nombre = "Avtividades Personales",
        Peso = 20 
        });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaID);

            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea()
        {
            TareaID = Guid.Parse("9a1747dc-c512-4c0e-80ea-9b1baffd71ab"),
            CategoriaID = Guid.Parse("9a1747dc-c512-4c0e-80ea-9b1baffd716c"),
            PrioridadTarea = Prioridad.Media,
            Titulo = "Pagos de servicios publicos",
            FechaCreacion =DateTime.Now
        });
        tareasInit.Add(new Tarea()
        {
            TareaID = Guid.Parse("9a1747dc-c512-4c0e-80ea-9b1baffd71bc"),
            CategoriaID = Guid.Parse("9a1747dc-c512-4c0e-80ea-9b1baffd7152"),
            PrioridadTarea = Prioridad.Baja,
            Titulo = "Ver pelicula en HBO",
            FechaCreacion =DateTime.Now
        });

        modelBuilder.Entity<Tarea>(tarea => 
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaID);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaID);

            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
            tarea.HasData(tareasInit);
        });
    }
}