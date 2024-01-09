﻿// <auto-generated />
using System;
using Colegio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Colegio.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Colegio.Models.Acudiente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EstudianteHijoId")
                        .HasColumnType("bigint");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteHijoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Acudientes");
                });

            modelBuilder.Entity("Colegio.Models.Administrador", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("UsuarioId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("Colegio.Models.Curso", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("text");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Codigo");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Colegio.Models.Estudiante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CursoCodigo")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CursoCodigo");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("Colegio.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CursoCodigo")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ProfesorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CursoCodigo");

                    b.HasIndex("ProfesorId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Colegio.Models.Nota", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PeriodoId")
                        .HasColumnType("integer");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PeriodoId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Colegio.Models.NotaEstudiante", b =>
                {
                    b.Property<long>("EstudianteNumeroDocumento")
                        .HasColumnType("bigint");

                    b.Property<long>("NotaId")
                        .HasColumnType("bigint");

                    b.HasKey("EstudianteNumeroDocumento", "NotaId");

                    b.HasIndex("NotaId");

                    b.ToTable("NotasEstudiantes");
                });

            modelBuilder.Entity("Colegio.Models.Periodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("FechaFin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaInicio")
                        .HasColumnType("date");

                    b.Property<int>("MateriaId")
                        .HasColumnType("integer");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.ToTable("Periodos");
                });

            modelBuilder.Entity("Colegio.Models.Profesor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("UsuarioId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("Colegio.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("NumeroDocumento");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("DireccionResidencia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Edad")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("GrupoSanguineo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = "Administrador",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "Estudiante",
                            Name = "Estudiante",
                            NormalizedName = "ESTUDIANTE"
                        },
                        new
                        {
                            Id = "Acudiente",
                            Name = "Acudiente",
                            NormalizedName = "ACUDIENTE"
                        },
                        new
                        {
                            Id = "Profesor",
                            Name = "Profesor",
                            NormalizedName = "PROFESOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Colegio.Models.Rol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("Rol");
                });

            modelBuilder.Entity("Colegio.Models.Acudiente", b =>
                {
                    b.HasOne("Colegio.Models.Estudiante", "EstudianteHijo")
                        .WithMany()
                        .HasForeignKey("EstudianteHijoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Colegio.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("EstudianteHijo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Colegio.Models.Administrador", b =>
                {
                    b.HasOne("Colegio.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Colegio.Models.Estudiante", b =>
                {
                    b.HasOne("Colegio.Models.Curso", "Curso")
                        .WithMany("Estudiantes")
                        .HasForeignKey("CursoCodigo");

                    b.HasOne("Colegio.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Curso");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Colegio.Models.Materia", b =>
                {
                    b.HasOne("Colegio.Models.Curso", "Curso")
                        .WithMany("Materias")
                        .HasForeignKey("CursoCodigo");

                    b.HasOne("Colegio.Models.Profesor", "Profesor")
                        .WithMany("Materias")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Colegio.Models.Nota", b =>
                {
                    b.HasOne("Colegio.Models.Periodo", "Periodo")
                        .WithMany("Notas")
                        .HasForeignKey("PeriodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Periodo");
                });

            modelBuilder.Entity("Colegio.Models.NotaEstudiante", b =>
                {
                    b.HasOne("Colegio.Models.Estudiante", "Estudiante")
                        .WithMany("NotasEstudiantes")
                        .HasForeignKey("EstudianteNumeroDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Colegio.Models.Nota", "Nota")
                        .WithMany("NotasEstudiantes")
                        .HasForeignKey("NotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Nota");
                });

            modelBuilder.Entity("Colegio.Models.Periodo", b =>
                {
                    b.HasOne("Colegio.Models.Materia", "Materia")
                        .WithMany("Periodos")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Colegio.Models.Profesor", b =>
                {
                    b.HasOne("Colegio.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Colegio.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Colegio.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Colegio.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Colegio.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Colegio.Models.Curso", b =>
                {
                    b.Navigation("Estudiantes");

                    b.Navigation("Materias");
                });

            modelBuilder.Entity("Colegio.Models.Estudiante", b =>
                {
                    b.Navigation("NotasEstudiantes");
                });

            modelBuilder.Entity("Colegio.Models.Materia", b =>
                {
                    b.Navigation("Periodos");
                });

            modelBuilder.Entity("Colegio.Models.Nota", b =>
                {
                    b.Navigation("NotasEstudiantes");
                });

            modelBuilder.Entity("Colegio.Models.Periodo", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("Colegio.Models.Profesor", b =>
                {
                    b.Navigation("Materias");
                });
#pragma warning restore 612, 618
        }
    }
}
