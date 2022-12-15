using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.Infastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SocketConnection",
                table: "Device",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocketConnection",
                table: "Device");
        }
    }
}
