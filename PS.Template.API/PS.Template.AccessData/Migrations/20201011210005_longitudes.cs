using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Template.AccessData.Migrations
{
    public partial class longitudes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Alto",
                table: "Paquete",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ancho",
                table: "Paquete",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Largo",
                table: "Paquete",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alto",
                table: "Paquete");

            migrationBuilder.DropColumn(
                name: "Ancho",
                table: "Paquete");

            migrationBuilder.DropColumn(
                name: "Largo",
                table: "Paquete");
        }
    }
}
