using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colegio.Migrations
{
    /// <inheritdoc />
    public partial class EliminacionCorreoTelefono : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Acudientes");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Acudientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Profesores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Telefono",
                table: "Profesores",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Estudiantes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Telefono",
                table: "Estudiantes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Administradores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Telefono",
                table: "Administradores",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Acudientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Telefono",
                table: "Acudientes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
