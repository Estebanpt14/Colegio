using Colegio.Models;
using Colegio.Utilities;
using Colegio.Utilities.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Data;

public class DataContext : IdentityDbContext<Usuario>
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

    public DbSet<Rol> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar la nueva columna de la clave primaria en ApplicationUser
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Id)
            .HasColumnName("NumeroDocumento");
        modelBuilder.Entity<Usuario>()
            .HasAlternateKey(u => u.Id);

        // Configurar la nueva columna de la clave primaria en IdentityRole
        modelBuilder.Entity<IdentityRole>()
            .Property(r => r.Id)
            .HasColumnName("Id");
        modelBuilder.Entity<IdentityRole>()
            .HasAlternateKey(r => r.Id);

        // Configurar claves primarias de IdentityUserLogin, IdentityUserRole y IdentityUserToken
        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(l => new { l.LoginProvider, l.ProviderKey });
        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasKey(r => new { r.UserId, r.RoleId });
        modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

        // Configurar relación de NotaEstudiante con claves primarias
        modelBuilder.Entity<NotaEstudiante>()
            .HasKey(ne => new { ne.EstudianteNumeroDocumento, ne.NotaId });
        modelBuilder.Entity<NotaEstudiante>()
            .HasOne(ne => ne.Nota)
            .WithMany(n => n.NotasEstudiantes)
            .HasForeignKey(ne => ne.NotaId);
        modelBuilder.Entity<NotaEstudiante>()
            .HasOne(ne => ne.Estudiante)
            .WithMany(e => e.NotasEstudiantes)
            .HasForeignKey(ne => ne.EstudianteNumeroDocumento);

        // Configurar datos iniciales (seed data) para Roles
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = DatabaseRoles.Administrador, NormalizedName = DatabaseRoles.Administrador.ToUpper() },
            new IdentityRole { Id = "2", Name = DatabaseRoles.Estudiante, NormalizedName = DatabaseRoles.Estudiante.ToUpper() },
            new IdentityRole { Id = "3", Name = DatabaseRoles.Acudiente, NormalizedName = DatabaseRoles.Acudiente.ToUpper() },
            new IdentityRole { Id = "4", Name = DatabaseRoles.Profesor, NormalizedName = DatabaseRoles.Profesor.ToUpper() }
        );
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = "1",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "default@gmail.com",
                PasswordHash = Encryptor.Encrypt("1234"),
                Nombre = "Admin",
                DireccionResidencia = "Direccion Colegio",
                GrupoSanguineo = "NA"
            }
        );
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                UsuarioId = "1"
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            }
        );

        base.OnModelCreating(modelBuilder);
    }

}