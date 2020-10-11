using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Template.AccessData.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Envio",
                columns: table => new
                {
                    idEnvio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSucOrigen = table.Column<int>(nullable: false),
                    idSucDestino = table.Column<int>(nullable: false),
                    idUserOrigen = table.Column<int>(nullable: false),
                    idUserDestino = table.Column<int>(nullable: false),
                    Costo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envio", x => x.idEnvio);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    idEstado = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.idEstado);
                });

            migrationBuilder.CreateTable(
                name: "TipoPaquete",
                columns: table => new
                {
                    idTipoPaquete = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPaquete", x => x.idTipoPaquete);
                });

            migrationBuilder.CreateTable(
                name: "SucursalPorEnvio",
                columns: table => new
                {
                    idSucursalPorEnvio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEnvio = table.Column<int>(nullable: false),
                    idSucursal = table.Column<int>(nullable: false),
                    idEstado = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucursalPorEnvio", x => x.idSucursalPorEnvio);
                    table.ForeignKey(
                        name: "FK_SucursalPorEnvio_Envio",
                        column: x => x.idEnvio,
                        principalTable: "Envio",
                        principalColumn: "idEnvio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SucursalPorEnvio_Estado",
                        column: x => x.idEstado,
                        principalTable: "Estado",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    idPaquete = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Peso = table.Column<int>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    Largo = table.Column<int>(nullable: false),
                    Ancho = table.Column<int>(nullable: false),
                    Alto = table.Column<int>(nullable: false),
                    Dimension = table.Column<int>(nullable: false),
                    idTipoPaquete = table.Column<int>(nullable: false),
                    idEnvio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.idPaquete);
                    table.ForeignKey(
                        name: "FK_Paquete_Envio",
                        column: x => x.idEnvio,
                        principalTable: "Envio",
                        principalColumn: "idEnvio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paquete_TipoPaquete",
                        column: x => x.idTipoPaquete,
                        principalTable: "TipoPaquete",
                        principalColumn: "idTipoPaquete",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "idEstado", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Ingreso a la sucursal" },
                    { 2, "En espera" },
                    { 3, "Despachado" }
                });

            migrationBuilder.InsertData(
                table: "TipoPaquete",
                columns: new[] { "idTipoPaquete", "Descripcion", "Valor" },
                values: new object[,]
                {
                    { 1, "Caja", 600 },
                    { 2, "Bolsin", 500 },
                    { 3, "Carta documento", 950 },
                    { 4, "Telegrama", 500 },
                    { 5, "Carta simple", 300 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_idEnvio",
                table: "Paquete",
                column: "idEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_idTipoPaquete",
                table: "Paquete",
                column: "idTipoPaquete");

            migrationBuilder.CreateIndex(
                name: "IX_SucursalPorEnvio_idEnvio",
                table: "SucursalPorEnvio",
                column: "idEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_SucursalPorEnvio_idEstado",
                table: "SucursalPorEnvio",
                column: "idEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "SucursalPorEnvio");

            migrationBuilder.DropTable(
                name: "TipoPaquete");

            migrationBuilder.DropTable(
                name: "Envio");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
