namespace Colegio.Dto;

public class UsuarioDto
{
    public string UserName { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    public string NumeroDocumento { get; set; }
    
    public string Nombre { get; set; }

    public int Edad { get; set; }
    
    public string GrupoSanguineo { get; set; }
    
    public string DireccionResidencia { get; set; }

    public DateOnly FechaNacimiento { get; set; }
}