using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Acudiente
{
    [Key]
    public long Id { get; set; }

    public string UsuarioId { get; set; }

    public long EstudianteId { get; set; }

    public Estudiante EstudianteHijo { get; set; }

    public Usuario Usuario { get; set; }
}