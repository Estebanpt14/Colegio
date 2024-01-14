using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Profesor
{
    [Key]
    public long Id { get; set; }

    public string UsuarioId { get; set; }
    
    public ICollection<Materia> Materias { get; set; }
    
    public Usuario Usuario { get; set; }
    
}