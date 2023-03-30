using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarVillaTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 28, 21, 31, 56, 248, DateTimeKind.Local).AddTicks(9223), new DateTime(2023, 3, 28, 21, 31, 56, 248, DateTimeKind.Local).AddTicks(9206) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 28, 21, 31, 56, 248, DateTimeKind.Local).AddTicks(9229), new DateTime(2023, 3, 28, 21, 31, 56, 248, DateTimeKind.Local).AddTicks(9228) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 28, 20, 56, 20, 206, DateTimeKind.Local).AddTicks(8787), new DateTime(2023, 3, 28, 20, 56, 20, 206, DateTimeKind.Local).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 28, 20, 56, 20, 206, DateTimeKind.Local).AddTicks(8793), new DateTime(2023, 3, 28, 20, 56, 20, 206, DateTimeKind.Local).AddTicks(8791) });
        }
    }
}
