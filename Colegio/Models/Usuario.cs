using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Colegio.Models;

public class Usuario : IdentityUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("NumeroDocumento")]
    public override string Id { get; set; }

    public string Nombre { get; set; }

    public int Edad { get; set; }

    public string GrupoSanguineo { get; set; }

    public string DireccionResidencia { get; set; }

    public DateOnly FechaNacimiento { get; set; }
}