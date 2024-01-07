using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Administrador
{
    [Key]
    public long NumeroDocumento { get; set; }
    
    public string Nombre { get; set; }

    public int Edad { get; set; }
    
    public string GrupoSanguineo { get; set; }
    
    public string DireccionResidencia { get; set; }

    public DateOnly FechaNacimiento { get; set; }
    
    public Usuario Usuario { get; set; }
}