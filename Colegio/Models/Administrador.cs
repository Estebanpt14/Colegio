using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Administrador
{
    [Key]
    public long Id { get; set; }
    
    public string UsuarioId { get; set; }
    
    public Usuario Usuario { get; set; }
}