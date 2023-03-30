using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNumeroVillaTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 28, 21, 34, 6, 784, DateTimeKind.Local).AddTicks(153), new DateTime(2023, 3, 28, 21, 34, 6, 784, DateTimeKind.Local).AddTicks(130) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 3, 28, 21, 34, 6, 784, DateTimeKind.Local).AddTicks(159), new DateTime(2023, 3, 28, 21, 34, 6, 784, DateTimeKind.Local).AddTicks(158) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
