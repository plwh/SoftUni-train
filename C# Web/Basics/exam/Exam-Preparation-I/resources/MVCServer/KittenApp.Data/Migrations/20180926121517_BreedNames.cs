using Microsoft.EntityFrameworkCore.Migrations;

namespace KittenApp.Data.Migrations
{
    public partial class BreedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Breeds",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Breeds",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
