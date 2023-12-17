using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Periodo
{
    [Key]
    public int Id { get; set; }

    public int Numero { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public Materia Materia { get; set; }

    public ICollection<Nota> Notas { get; set; }
}