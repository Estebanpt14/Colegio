using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Acudiente
{
    [Key]
    public long NumeroDocumento { get; set; }
    
    public string Nombre { get; set; }

    public int Edad { get; set; }

    public string Correo { get; set; }
    
    public string GrupoSanguineo { get; set; }
    
    public string DireccionResidencia { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public long Telefono { get; set; }

    public Estudiante EstudianteHijo { get; set; }
}