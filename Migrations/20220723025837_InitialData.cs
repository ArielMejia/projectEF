using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEF.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd7152"), null, "Avtividades Personales", 20 },
                    { new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd716c"), null, "Avtividades Pendientes", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaID", "CategoriaID", "Descripcion", "FechaCreacion", "PrioridadTarea", "TareaID1", "Titulo" },
                values: new object[,]
                {
                    { new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd71ab"), new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd716c"), null, new DateTime(2022, 7, 22, 20, 58, 36, 531, DateTimeKind.Local).AddTicks(191), 1, null, "Pagos de servicios publicos" },
                    { new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd71bc"), new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd7152"), null, new DateTime(2022, 7, 22, 20, 58, 36, 531, DateTimeKind.Local).AddTicks(206), 0, null, "Ver pelicula en HBO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd71ab"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd71bc"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd7152"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("9a1747dc-c512-4c0e-80ea-9b1baffd716c"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
