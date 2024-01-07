using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Colegio.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    NumeroDocumento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "text", nullable: false),
                    DireccionResidencia = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefono = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.NumeroDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    NumeroDocumento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "text", nullable: false),
                    DireccionResidencia = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefono = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.NumeroDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    NumeroDocumento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "text", nullable: false),
                    DireccionResidencia = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefono = table.Column<int>(type: "integer", nullable: false),
                    CursoCodigo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.NumeroDocumento);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Cursos_CursoCodigo",
                        column: x => x.CursoCodigo,
                        principalTable: "Cursos",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    CursoCodigo = table.Column<string>(type: "text", nullable: true),
                    ProfesorNumeroDocumento = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Cursos_CursoCodigo",
                        column: x => x.CursoCodigo,
                        principalTable: "Cursos",
                        principalColumn: "Codigo");
                    table.ForeignKey(
                        name: "FK_Materias_Profesores_ProfesorNumeroDocumento",
                        column: x => x.ProfesorNumeroDocumento,
                        principalTable: "Profesores",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acudientes",
                columns: table => new
                {
                    NumeroDocumento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "text", nullable: false),
                    DireccionResidencia = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefono = table.Column<int>(type: "integer", nullable: false),
                    EstudianteHijoNumeroDocumento = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acudientes", x => x.NumeroDocumento);
                    table.ForeignKey(
                        name: "FK_Acudientes_Estudiantes_EstudianteHijoNumeroDocumento",
                        column: x => x.EstudianteHijoNumeroDocumento,
                        principalTable: "Estudiantes",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Periodos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    MateriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periodos_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    PeriodoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Periodos_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasEstudiantes",
                columns: table => new
                {
                    NotaId = table.Column<long>(type: "bigint", nullable: false),
                    EstudianteNumeroDocumento = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasEstudiantes", x => new { x.EstudianteNumeroDocumento, x.NotaId });
                    table.ForeignKey(
                        name: "FK_NotasEstudiantes_Estudiantes_EstudianteNumeroDocumento",
                        column: x => x.EstudianteNumeroDocumento,
                        principalTable: "Estudiantes",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotasEstudiantes_Notas_NotaId",
                        column: x => x.NotaId,
                        principalTable: "Notas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acudientes_EstudianteHijoNumeroDocumento",
                table: "Acudientes",
                column: "EstudianteHijoNumeroDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CursoCodigo",
                table: "Estudiantes",
                column: "CursoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_CursoCodigo",
                table: "Materias",
                column: "CursoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_ProfesorNumeroDocumento",
                table: "Materias",
                column: "ProfesorNumeroDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_PeriodoId",
                table: "Notas",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasEstudiantes_NotaId",
                table: "NotasEstudiantes",
                column: "NotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Periodos_MateriaId",
                table: "Periodos",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acudientes");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "NotasEstudiantes");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Periodos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
