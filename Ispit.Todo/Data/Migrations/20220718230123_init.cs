using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Todolist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorijaTodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todolist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todolist_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Akcija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TodolistId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskList_Todolist_TodolistId",
                        column: x => x.TodolistId,
                        principalTable: "Todolist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6b5b0da-e61e-46ba-b766-e1acc7401352", "fafb386e-706d-4837-964a-cc0206dcaf47", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "badd4ddd-df0e-4621-af37-c2b36aaa6742", 0, "abd0b719-b10c-47d4-91cc-d03b4b87fcbd", "ApplicationUser", "user@user.com", true, "Tvrdi", "Guz", false, null, "USER@USER.COM", "USER@USER.COM", "AQAAAAEAACcQAAAAEJaFikp+3s1Oa5Bj9w+HFmojDPjDwschQOE18fHWUZVSD2czPe7xTD9eTtC3OB0FOA==", null, false, "c8c5cc23-1703-4984-8ac7-4b178d2d9982", false, "user@user.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d6b5b0da-e61e-46ba-b766-e1acc7401352", "badd4ddd-df0e-4621-af37-c2b36aaa6742" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_TodolistId",
                table: "TaskList",
                column: "TodolistId");

            migrationBuilder.CreateIndex(
                name: "IX_Todolist_ApplicationUserId",
                table: "Todolist",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskList");

            migrationBuilder.DropTable(
                name: "Todolist");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d6b5b0da-e61e-46ba-b766-e1acc7401352", "badd4ddd-df0e-4621-af37-c2b36aaa6742" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6b5b0da-e61e-46ba-b766-e1acc7401352");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "badd4ddd-df0e-4621-af37-c2b36aaa6742");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
