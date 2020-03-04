using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleMvc.Data.Migrations
{
    public partial class Validations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_OwnerId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Notes",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_OwnerId",
                table: "Notes",
                newName: "IX_Notes_AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_AuthorId",
                table: "Notes",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_AuthorId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Notes",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_AuthorId",
                table: "Notes",
                newName: "IX_Notes_OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_OwnerId",
                table: "Notes",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
