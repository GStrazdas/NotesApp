using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesApp.Migrations
{
    public partial class NotesFieldsCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetUsers_NotesAppUserId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_AspNetUsers_NotesAppUserId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Category_CategoryId",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Note_NotesAppUserId",
                table: "Notes",
                newName: "IX_Notes_NotesAppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Note_CategoryId",
                table: "Notes",
                newName: "IX_Notes_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_NotesAppUserId",
                table: "Categories",
                newName: "IX_Categories_NotesAppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "NotesAppUserId",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_NotesAppUserId",
                table: "Categories",
                column: "NotesAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_NotesAppUserId",
                table: "Notes",
                column: "NotesAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                table: "Notes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_NotesAppUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_NotesAppUserId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_NotesAppUserId",
                table: "Note",
                newName: "IX_Note_NotesAppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_CategoryId",
                table: "Note",
                newName: "IX_Note_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_NotesAppUserId",
                table: "Category",
                newName: "IX_Category_NotesAppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "NotesAppUserId",
                table: "Note",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetUsers_NotesAppUserId",
                table: "Category",
                column: "NotesAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_AspNetUsers_NotesAppUserId",
                table: "Note",
                column: "NotesAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Category_CategoryId",
                table: "Note",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
