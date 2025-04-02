using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maquiagem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddCompraCarrinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Compra",
                table: "Compra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho");

            migrationBuilder.RenameTable(
                name: "Compra",
                newName: "Compra",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Carrinho",
                newName: "Carrinho",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compra",
                schema: "dbo",
                table: "Compra",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinho",
                schema: "dbo",
                table: "Carrinho",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateTable(
                name: "CompraItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraItem", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraItem",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compra",
                schema: "dbo",
                table: "Compra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinho",
                schema: "dbo",
                table: "Carrinho");

            migrationBuilder.RenameTable(
                name: "Compra",
                schema: "dbo",
                newName: "Compra");

            migrationBuilder.RenameTable(
                name: "Carrinho",
                schema: "dbo",
                newName: "Carrinho");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compra",
                table: "Compra",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho",
                column: "Id");
        }
    }
}
