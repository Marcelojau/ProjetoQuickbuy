using Microsoft.EntityFrameworkCore.Migrations;

namespace Quickbuy.Repositorio.Migrations
{
    public partial class addColumnAdminTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EhAdministrador",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EhAdministrador",
                table: "Usuarios");
        }
    }
}
