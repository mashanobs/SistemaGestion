using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionData.Migrations
{
    /// <inheritdoc />
    public partial class createmigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "ProductoVendido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "ProductoVendido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_UsuarioId",
                table: "Venta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVendido_ProductoId",
                table: "ProductoVendido",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVendido_VentaId",
                table: "ProductoVendido",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoVendido_Productos_ProductoId",
                table: "ProductoVendido",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoVendido_Venta_VentaId",
                table: "ProductoVendido",
                column: "VentaId",
                principalTable: "Venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Usuarios_UsuarioId",
                table: "Venta",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoVendido_Productos_ProductoId",
                table: "ProductoVendido");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoVendido_Venta_VentaId",
                table: "ProductoVendido");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Usuarios_UsuarioId",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_UsuarioId",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_ProductoVendido_ProductoId",
                table: "ProductoVendido");

            migrationBuilder.DropIndex(
                name: "IX_ProductoVendido_VentaId",
                table: "ProductoVendido");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "ProductoVendido");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "ProductoVendido");
        }
    }
}
