using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Template.AccessData.Migrations
{
    public partial class agregarEstados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "idEstado",
                keyValue: 2,
                column: "Descripcion",
                value: "En proceso");

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "idEstado", "Descripcion" },
                values: new object[] { 5, "Entregado" });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "idEstado", "Descripcion" },
                values: new object[] { 4, "En viaje al domicilio del destinatiario" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "idEstado",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "idEstado",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "idEstado",
                keyValue: 2,
                column: "Descripcion",
                value: "En espera");
        }
    }
}
