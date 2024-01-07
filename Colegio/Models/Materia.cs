using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Materia
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; }

    public Curso Curso { get; set; }

    public Profesor Profesor { get; set; }

    public ICollection<Periodo> Periodos { get; set; }
}