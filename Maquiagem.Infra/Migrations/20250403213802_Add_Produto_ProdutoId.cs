using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maquiagem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Produto_ProdutoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                schema: "dbo",
                table: "Produto",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoId",
                schema: "dbo",
                table: "Produto");
        }
    }
}
