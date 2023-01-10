using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.Infastructure.Migrations
{
    public partial class date110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActiveTime",
                table: "Device",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveTime",
                table: "Device");
        }
    }
}
