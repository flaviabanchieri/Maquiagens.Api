using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maquiagem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorEscolhidaHex",
                schema: "dbo",
                table: "Carrinho",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                schema: "dbo",
                table: "Carrinho",
                type: "int",
                nullable: false,
                defaultValue: 0);

			migrationBuilder.AlterColumn<int>(
	            name: "UsuarioId",
	            schema: "dbo",
	            table: "Carrinho",
	            type: "int",
	            nullable: true,
	            oldClrType: typeof(long),
	            oldType: "bigint",
	            oldNullable: true);

			migrationBuilder.CreateTable(
                name: "Produto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: false),
                    Price = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: false),
                    PriceSign = table.Column<string>(type: "varchar(100)", maxLength: 10, nullable: false),
                    Currency = table.Column<string>(type: "varchar(100)", maxLength: 10, nullable: false),
                    ImageLink = table.Column<string>(type: "varchar(100)", maxLength: 500, nullable: false),
                    ProductLink = table.Column<string>(type: "varchar(100)", maxLength: 500, nullable: false),
                    WebsiteLink = table.Column<string>(type: "varchar(100)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    Category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ProductType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TagList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ProductApiUrl = table.Column<string>(type: "varchar(100)", maxLength: 500, nullable: false),
                    ApiFeaturedImage = table.Column<string>(type: "varchar(100)", maxLength: 500, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorProduto",
                schema: "dbo",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HexValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColourName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorProduto", x => new { x.ProdutoId, x.Id });
                    table.ForeignKey(
                        name: "FK_CorProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalSchema: "dbo",
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraItem_CompraId",
                schema: "dbo",
                table: "CompraItem",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_ProdutoId",
                schema: "dbo",
                table: "Carrinho",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Produto_ProdutoId",
                schema: "dbo",
                table: "Carrinho",
                column: "ProdutoId",
                principalSchema: "dbo",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompraItem_Compra_CompraId",
                schema: "dbo",
                table: "CompraItem",
                column: "CompraId",
                principalSchema: "dbo",
                principalTable: "Compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Produto_ProdutoId",
                schema: "dbo",
                table: "Carrinho");


            migrationBuilder.DropForeignKey(
                name: "FK_CompraItem_Compra_CompraId",
                schema: "dbo",
                table: "CompraItem");

            migrationBuilder.DropTable(
                name: "CorProduto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Produto",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_CompraItem_CompraId",
                schema: "dbo",
                table: "CompraItem");

            migrationBuilder.DropIndex(
                name: "IX_Carrinho_ProdutoId",
                schema: "dbo",
                table: "Carrinho");

            migrationBuilder.DropColumn(
                name: "CorEscolhidaHex",
                schema: "dbo",
                table: "Carrinho");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                schema: "dbo",
                table: "Carrinho");

			migrationBuilder.AlterColumn<long>(
		        name: "UsuarioId",
		        schema: "dbo",
		        table: "Carrinho",
		        type: "bigint",
		        nullable: true,
		        oldClrType: typeof(int),
		        oldType: "int",
		        oldNullable: true);
		}
    }
}
