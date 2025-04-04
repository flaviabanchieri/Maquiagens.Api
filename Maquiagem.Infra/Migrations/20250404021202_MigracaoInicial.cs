using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maquiagem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Produto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 255, nullable: false),
                    Price = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: true),
                    PriceSign = table.Column<string>(type: "varchar(100)", maxLength: 10, nullable: true),
                    Currency = table.Column<string>(type: "varchar(100)", maxLength: 10, nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    Category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ProductType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    TagList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ProductApiUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiFeaturedImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
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

            migrationBuilder.CreateTable(
                name: "Carrinho",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CorEscolhidaHex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Carrinho_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalSchema: "dbo",
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrinho_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Compra_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompraItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CorEscolhidaHex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraItem", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CompraItem_Compra_CompraId",
                        column: x => x.CompraId,
                        principalSchema: "dbo",
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraItem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalSchema: "dbo",
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompraItem_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "Usuario",
                        principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_ProdutoId",
                schema: "dbo",
                table: "Carrinho",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_UsuarioId",
                schema: "dbo",
                table: "Carrinho",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UsuarioId",
                schema: "dbo",
                table: "Compra",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraItem_CompraId",
                schema: "dbo",
                table: "CompraItem",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraItem_ProdutoId",
                schema: "dbo",
                table: "CompraItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraItem_UsuarioId",
                schema: "dbo",
                table: "CompraItem",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrinho",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CompraItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CorProduto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Compra",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Produto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");
        }
    }
}
