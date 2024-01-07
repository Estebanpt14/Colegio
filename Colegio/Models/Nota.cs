using System.ComponentModel.DataAnnotations;

namespace Colegio.Models;

public class Nota
{
    [Key]
    public long Id { get; set; }

    public float Valor { get; set; }

    public string Descripcion { get; set; }

    public Periodo Periodo { get; set; }

    public ICollection<NotaEstudiante> NotasEstudiantes { get; set; }
}