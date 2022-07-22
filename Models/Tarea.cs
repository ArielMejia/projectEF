namespace projectEF.Models;

public class Tarea
{
    public Guid TareaID {get; set;}
    public Guid CategoriaID {get;set;}
    public string Titulo {get; set;}
    public string Descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}
    public virtual Categoria Categoria {get;set;}
    public virtual ICollection<Tarea> Tareas {get;set;}
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}