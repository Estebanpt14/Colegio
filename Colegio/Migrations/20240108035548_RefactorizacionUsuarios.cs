using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Colegio.Migrations
{
    /// <inheritdoc />
    public partial class RefactorizacionUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_Estudiantes_EstudianteHijoNumeroDocumento",
                table: "Acudientes");

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
                name: "FK_Materias_Profesores_ProfesorNumeroDocumento",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Usuarios_UsuarioId",
                table: "Profesores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DireccionResidencia",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "GrupoSanguineo",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "DireccionResidencia",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "GrupoSanguineo",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "DireccionResidencia",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "GrupoSanguineo",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "DireccionResidencia",
                table: "Acudientes");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Acudientes");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Acudientes");

            migrationBuilder.DropColumn(
                name: "GrupoSanguineo",
                table: "Acudientes");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Acudientes");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "NumeroDocumento",
                table: "Profesores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfesorNumeroDocumento",
                table: "Materias",
                newName: "ProfesorId");

            migrationBuilder.RenameIndex(
                name: "IX_Materias_ProfesorNumeroDocumento",
                table: "Materias",
                newName: "IX_Materias_ProfesorId");

            migrationBuilder.RenameColumn(
                name: "NumeroDocumento",
                table: "Estudiantes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NumeroDocumento",
                table: "Administradores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EstudianteHijoNumeroDocumento",
                table: "Acudientes",
                newName: "EstudianteHijoId");

            migrationBuilder.RenameColumn(
                name: "NumeroDocumento",
                table: "Acudientes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Acudientes_EstudianteHijoNumeroDocumento",
                table: "Acudientes",
                newName: "IX_Acudientes_EstudianteHijoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUsers",
                newName: "NumeroDocumento");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DireccionResidencia",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaNacimiento",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "GrupoSanguineo",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "NumeroDocumento");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Acudiente", null, "IdentityRole", "Acudiente", "ACUDIENTE" },
                    { "Administrador", null, "IdentityRole", "Administrador", "ADMINISTRADOR" },
                    { "Estudiante", null, "IdentityRole", "Estudiante", "ESTUDIANTE" },
                    { "Profesor", null, "IdentityRole", "Profesor", "PROFESOR" }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

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
                name: "FK_Materias_Profesores_ProfesorId",
                table: "Materias",
                column: "ProfesorId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_AspNetUsers_UsuarioId",
                table: "Profesores",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "NumeroDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Materias_Profesores_ProfesorId",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_AspNetUsers_UsuarioId",
                table: "Profesores");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DireccionResidencia",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GrupoSanguineo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profesores",
                newName: "NumeroDocumento");

            migrationBuilder.RenameColumn(
                name: "ProfesorId",
                table: "Materias",
                newName: "ProfesorNumeroDocumento");

            migrationBuilder.RenameIndex(
                name: "IX_Materias_ProfesorId",
                table: "Materias",
                newName: "IX_Materias_ProfesorNumeroDocumento");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Estudiantes",
                newName: "NumeroDocumento");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Administradores",
                newName: "NumeroDocumento");

            migrationBuilder.RenameColumn(
                name: "EstudianteHijoId",
                table: "Acudientes",
                newName: "EstudianteHijoNumeroDocumento");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Acudientes",
                newName: "NumeroDocumento");

            migrationBuilder.RenameIndex(
                name: "IX_Acudientes_EstudianteHijoId",
                table: "Acudientes",
                newName: "IX_Acudientes_EstudianteHijoNumeroDocumento");

            migrationBuilder.RenameColumn(
                name: "NumeroDocumento",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "DireccionResidencia",
                table: "Profesores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Profesores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaNacimiento",
                table: "Profesores",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "GrupoSanguineo",
                table: "Profesores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Profesores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DireccionResidencia",
                table: "Estudiantes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Estudiantes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaNacimiento",
                table: "Estudiantes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "GrupoSanguineo",
                table: "Estudiantes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Estudiantes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DireccionResidencia",
                table: "Administradores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Administradores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaNacimiento",
                table: "Administradores",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "GrupoSanguineo",
                table: "Administradores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Administradores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DireccionResidencia",
                table: "Acudientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Acudientes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaNacimiento",
                table: "Acudientes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "GrupoSanguineo",
                table: "Acudientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Acudientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_Estudiantes_EstudianteHijoNumeroDocumento",
                table: "Acudientes",
                column: "EstudianteHijoNumeroDocumento",
                principalTable: "Estudiantes",
                principalColumn: "NumeroDocumento",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Materias_Profesores_ProfesorNumeroDocumento",
                table: "Materias",
                column: "ProfesorNumeroDocumento",
                principalTable: "Profesores",
                principalColumn: "NumeroDocumento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Usuarios_UsuarioId",
                table: "Profesores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
