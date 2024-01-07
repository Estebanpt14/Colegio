using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colegio.Migrations
{
    /// <inheritdoc />
    public partial class CreacionUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Profesores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Estudiantes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Administradores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Acudientes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EsActivo = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_UsuarioId",
                table: "Profesores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_UsuarioId",
                table: "Estudiantes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_UsuarioId",
                table: "Administradores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Acudientes_UsuarioId",
                table: "Acudientes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_Usuario_UsuarioId",
                table: "Acudientes",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_Usuario_UsuarioId",
                table: "Administradores",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Usuario_UsuarioId",
                table: "Estudiantes",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Usuario_UsuarioId",
                table: "Profesores",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_Usuario_UsuarioId",
                table: "Acudientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_Usuario_UsuarioId",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Usuario_UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Usuario_UsuarioId",
                table: "Profesores");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Profesores_UsuarioId",
                table: "Profesores");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Administradores_UsuarioId",
                table: "Administradores");

            migrationBuilder.DropIndex(
                name: "IX_Acudientes_UsuarioId",
                table: "Acudientes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Acudientes");
        }
    }
}
