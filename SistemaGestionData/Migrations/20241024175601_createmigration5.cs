using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionData.Migrations
{
    /// <inheritdoc />
    public partial class createmigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoVendido_Productos_ProductoId",
                table: "ProductoVendido");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoVendido_Venta_IdVenta",
                table: "ProductoVendido");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Usuarios_IdUsuario",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdUsuario",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_ProductoVendido_IdVenta",
                table: "ProductoVendido");

            migrationBuilder.DropIndex(
                name: "IX_ProductoVendido_ProductoId",
                table: "ProductoVendido");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "ProductoVendido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "ProductoVendido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdUsuario",
                table: "Venta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVendido_IdVenta",
                table: "ProductoVendido",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVendido_ProductoId",
                table: "ProductoVendido",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoVendido_Productos_ProductoId",
                table: "ProductoVendido",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoVendido_Venta_IdVenta",
                table: "ProductoVendido",
                column: "IdVenta",
                principalTable: "Venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Usuarios_IdUsuario",
                table: "Venta",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
