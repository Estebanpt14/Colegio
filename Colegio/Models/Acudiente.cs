using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Acudiente
{
    [Key]
    public long Id { get; set; }

    public Estudiante EstudianteHijo { get; set; }
    
    public Usuario Usuario { get; set; }
}