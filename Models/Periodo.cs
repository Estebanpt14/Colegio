namespace Colegio.Models;

public class Periodo
{
    public int Id { get; set; }

    public int Numero { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }
}