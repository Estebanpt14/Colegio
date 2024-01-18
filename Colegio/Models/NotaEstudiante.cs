using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class NotaEstudiante
{
    public long NotaId { get; set; }

    public long EstudianteNumeroDocumento { get; set; }

    public Nota Nota { get; set; }

    public Estudiante Estudiante { get; set; }
}