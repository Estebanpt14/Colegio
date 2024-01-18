using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Estudiante
{
    [Key]
    public long Id { get; set; }

    public string UsuarioId { get; set; }

    public string? CursoCodigo { get; set; }

    public Curso Curso { get; set; }

    public ICollection<NotaEstudiante> NotasEstudiantes { get; set; }

    public virtual Usuario Usuario { get; set; }
}