using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Template.AccessData.Migrations
{
    public partial class cambioTablaEnvio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idSucDestino",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "idSucOrigen",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "idUserDestino",
                table: "Envio");

            migrationBuilder.AddColumn<int>(
                name: "idDireccionDestino",
                table: "Envio",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idDireccionDestino",
                table: "Envio");

            migrationBuilder.AddColumn<int>(
                name: "idSucDestino",
                table: "Envio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idSucOrigen",
                table: "Envio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idUserDestino",
                table: "Envio",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
