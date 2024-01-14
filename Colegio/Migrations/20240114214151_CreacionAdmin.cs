using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colegio.Migrations
{
    /// <inheritdoc />
    public partial class CreacionAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_AspNetUsers_UsuarioId",
                table: "Acudientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_Estudiantes_EstudianteHijoId",
                table: "Acudientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_AspNetUsers_UsuarioId",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_AspNetUsers_UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodigo",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_AspNetUsers_UsuarioId",
                table: "Profesores");

            migrationBuilder.RenameColumn(
                name: "EstudianteHijoId",
                table: "Acudientes",
                newName: "EstudianteId");

            migrationBuilder.RenameIndex(
                name: "IX_Acudientes_EstudianteHijoId",
                table: "Acudientes",
                newName: "IX_Acudientes_EstudianteId");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Profesores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Estudiantes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CursoCodigo",
                table: "Estudiantes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Administradores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Acudientes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "UsuarioId" },
                values: new object[] { 1L, "1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "NumeroDocumento",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "105205b6-b83c-40ee-9cb3-4f73cab45a42", "d11a58b7-4018-4e9d-82e1-685fa967f1fc" });

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_AspNetUsers_UsuarioId",
                table: "Acudientes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "NumeroDocumento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_Estudiantes_EstudianteId",
                table: "Acudientes",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_AspNetUsers_UsuarioId",
                table: "Administradores",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "NumeroDocumento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_AspNetUsers_UsuarioId",
                table: "Estudiantes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "NumeroDocumento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodigo",
                table: "Estudiantes",
                column: "CursoCodigo",
                principalTable: "Cursos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_AspNetUsers_UsuarioId",
                table: "Profesores",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "NumeroDocumento",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_AspNetUsers_UsuarioId",
                table: "Acudientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_Estudiantes_EstudianteId",
                table: "Acudientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_AspNetUsers_UsuarioId",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_AspNetUsers_UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodigo",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_AspNetUsers_UsuarioId",
                table: "Profesores");

            migrationBuilder.DeleteData(
                table: "Administradores",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.RenameColumn(
                name: "EstudianteId",
                table: "Acudientes",
                newName: "EstudianteHijoId");

            migrationBuilder.RenameIndex(
                name: "IX_Acudientes_EstudianteId",
                table: "Acudientes",
                newName: "IX_Acudientes_EstudianteHijoId");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Profesores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Estudiantes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CursoCodigo",
                table: "Estudiantes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Administradores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Acudientes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "NumeroDocumento",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "74fea56b-1aa6-4792-a13c-7e74f6df0513", "5d0bff5f-e9e2-48c0-98e5-9f276b59162d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_AspNetUsers_UsuarioId",
                table: "Acudientes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "NumeroDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_Estudiantes_EstudianteHijoId",
                table: "Acudientes",
                column: "EstudianteHijoId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_AspNetUsers_UsuarioId",
                table: "Administradores",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "NumeroDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_AspNetUsers_UsuarioId",
                table: "Estudiantes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "NumeroDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodigo",
                table: "Estudiantes",
                column: "CursoCodigo",
                principalTable: "Cursos",
                principalColumn: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_AspNetUsers_UsuarioId",
                table: "Profesores",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "NumeroDocumento");
        }
    }
}
