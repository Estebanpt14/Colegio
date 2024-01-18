namespace Colegio.Dto;

public class EstudianteDto
{
    public string NumeroDocumento { get; set; }

    public string Username { get; set; }

    public string Nombre { get; set; }

    public int Edad { get; set; }

    public string GrupoSanguineo { get; set; }

    public string DireccionResidencia { get; set; }

    public DateOnly FechaNacimiento { get; set; }
}