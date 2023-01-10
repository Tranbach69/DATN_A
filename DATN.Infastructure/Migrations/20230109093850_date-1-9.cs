using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.Infastructure.Migrations
{
    public partial class date19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpTime",
                table: "Device",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpTime",
                table: "Device");
        }
    }
}
