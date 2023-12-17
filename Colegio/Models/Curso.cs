using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Curso
{
    [Key]
    public string Codigo { get; set; }
    
    public string Observaciones { get; set; }

    public ICollection<Materia> Materias { get; set; }

    public ICollection<Estudiante> Estudiantes { get; set; }
}