using Colegio.Models;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Acudiente> Acudientes { get; set; }

    public DbSet<Administrador> Administradores { get; set; }

    public DbSet<Curso> Cursos { get; set; }

    public DbSet<Estudiante> Estudiantes { get; set; }

    public DbSet<Materia> Materias { get; set; }

    public DbSet<Nota> Notas { get; set; }

    public DbSet<NotaEstudiante> NotasEstudiantes { get; set; }

    public DbSet<Periodo> Periodos { get; set; }

    public DbSet<Profesor> Profesores { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NotaEstudiante>()
            .HasKey(notaEstudiante => new { notaEstudiante.EstudianteNumeroDocumento, notaEstudiante.NotaId });
        modelBuilder.Entity<NotaEstudiante>()
            .HasOne(notasEstudiantes => notasEstudiantes.Nota)
            .WithMany(notas => notas.NotasEstudiantes)
            .HasForeignKey(nota => nota.NotaId);
        modelBuilder.Entity<NotaEstudiante>()
            .HasOne(notasEstudiantes => notasEstudiantes.Estudiante)
            .WithMany(estudiantes => estudiantes.NotasEstudiantes)
            .HasForeignKey(estudiante => estudiante.EstudianteNumeroDocumento);
    }

}