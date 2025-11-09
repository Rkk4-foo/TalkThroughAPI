using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalkThroughAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserChatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserChat",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "varchar(40)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(40)", nullable: false),
                    UserName = table.Column<string>(type: "Varchar(40)", nullable: false),
                    ChatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChat", x => new { x.ChatId, x.UserId, x.UserName });
                    table.ForeignKey(
                        name: "FK_UserChat_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId");
                    table.ForeignKey(
                        name: "FK_UserChat_Users_UserId_UserName",
                        columns: x => new { x.UserId, x.UserName },
                        principalTable: "Users",
                        principalColumns: new[] { "Id", "UserName" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserChat_UserId_UserName",
                table: "UserChat",
                columns: new[] { "UserId", "UserName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChat");
        }
    }
}
