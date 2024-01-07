using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colegio.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_Usuarios_UsuarioId",
                table: "Acudientes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_Usuarios_UsuarioId",
                table: "Administradores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Usuarios_UsuarioId",
                table: "Estudiantes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Usuarios_UsuarioId",
                table: "Profesores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_Usuarios_UsuarioId",
                table: "Acudientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_Usuarios_UsuarioId",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Usuarios_UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Usuarios_UsuarioId",
                table: "Profesores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

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
    }
}
