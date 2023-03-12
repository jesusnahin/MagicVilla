using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeterosCuadrados",
                table: "Villas",
                newName: "MetrosCuadrados");

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la villa...", new DateTime(2023, 3, 11, 21, 41, 45, 398, DateTimeKind.Local).AddTicks(8679), new DateTime(2023, 3, 11, 21, 41, 45, 398, DateTimeKind.Local).AddTicks(8650), "", 50, "Villa Real", 5, 200.0 },
                    { 2, "", "Detalle de la villa...", new DateTime(2023, 3, 11, 21, 41, 45, 398, DateTimeKind.Local).AddTicks(8685), new DateTime(2023, 3, 11, 21, 41, 45, 398, DateTimeKind.Local).AddTicks(8684), "", 40, "Premiun", 4, 150.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "MetrosCuadrados",
                table: "Villas",
                newName: "MeterosCuadrados");
        }
    }
}
