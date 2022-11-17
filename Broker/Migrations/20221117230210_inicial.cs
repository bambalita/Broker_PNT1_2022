using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Broker.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccionID = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantDinero = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Personas_Direcciones_direccionID",
                        column: x => x.direccionID,
                        principalTable: "Direcciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acciones_Personas_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Personas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioCompra = table.Column<double>(type: "float", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    AccionId = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsCompra = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Acciones_AccionId",
                        column: x => x.AccionId,
                        principalTable: "Acciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Personas_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Personas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_UsuarioID",
                table: "Acciones",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_AccionId",
                table: "Ordenes",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_UsuarioID",
                table: "Ordenes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_direccionID",
                table: "Personas",
                column: "direccionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Direcciones");
        }
    }
}
