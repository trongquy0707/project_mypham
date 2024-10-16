using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_my_pham.Migrations
{
    public partial class suataikhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "TAI_KHOAN",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SDT",
                table: "TAI_KHOAN");
        }
    }
}
