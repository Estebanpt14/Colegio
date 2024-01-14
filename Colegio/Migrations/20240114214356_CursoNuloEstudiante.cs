using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colegio.Migrations
{
    /// <inheritdoc />
    public partial class CursoNuloEstudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodigo",
                table: "Estudiantes");

            migrationBuilder.AlterColumn<string>(
                name: "CursoCodigo",
                table: "Estudiantes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "NumeroDocumento",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b2e18259-1ab2-42b6-927e-a06b0177e3f1", "bbbd7e31-788c-4feb-98f5-58d4d7465aaa" });

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodigo",
                table: "Estudiantes",
                column: "CursoCodigo",
                principalTable: "Cursos",
                principalColumn: "Codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodigo",
                table: "Estudiantes");

            migrationBuilder.AlterColumn<string>(
                name: "CursoCodigo",
                table: "Estudiantes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "NumeroDocumento",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "105205b6-b83c-40ee-9cb3-4f73cab45a42", "d11a58b7-4018-4e9d-82e1-685fa967f1fc" });

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Cursos_CursoCodigo",
                table: "Estudiantes",
                column: "CursoCodigo",
                principalTable: "Cursos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
