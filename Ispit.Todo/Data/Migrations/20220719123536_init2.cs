using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolist_AspNetUsers_ApplicationUserId",
                table: "Todolist");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Todolist",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "JeRjeseno",
                table: "TaskList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b5b0da-e61e-46ba-b766-e1acc7401352",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54bb7745-0cdc-4050-ad23-b8a6385194c5", "user", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "badd4ddd-df0e-4621-af37-c2b36aaa6742",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53efc3bf-d3fa-4a51-be9f-acb9db6ec475", "AQAAAAEAACcQAAAAEF0TnoGp5EDatNmUKY7fLJJtqqhlKkem5p9AcqrjvYcKe0BhAH4hBTxb8WYDpV8FQA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Todolist_AspNetUsers_ApplicationUserId",
                table: "Todolist",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolist_AspNetUsers_ApplicationUserId",
                table: "Todolist");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "badd4ddd-df0e-4621-af37-c2b36aaa6742");

            migrationBuilder.DropColumn(
                name: "JeRjeseno",
                table: "TaskList");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Todolist",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b5b0da-e61e-46ba-b766-e1acc7401352",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fafb386e-706d-4837-964a-cc0206dcaf47", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "badd4ddd-df0e-4621-af37-c2b36aaa6742", 0, "abd0b719-b10c-47d4-91cc-d03b4b87fcbd", "ApplicationUser", "user@user.com", true, "Tvrdi", "Guz", false, null, "USER@USER.COM", "USER@USER.COM", "AQAAAAEAACcQAAAAEJaFikp+3s1Oa5Bj9w+HFmojDPjDwschQOE18fHWUZVSD2czPe7xTD9eTtC3OB0FOA==", null, false, "c8c5cc23-1703-4984-8ac7-4b178d2d9982", false, "user@user.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_Todolist_AspNetUsers_ApplicationUserId",
                table: "Todolist",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
