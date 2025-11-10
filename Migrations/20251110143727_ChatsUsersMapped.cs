using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalkThroughAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChatsUsersMapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserChat",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar2(40)");

            migrationBuilder.CreateTable(
                name: "ChatUser",
                columns: table => new
                {
                    ChatsChatId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    UsersId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    UsersUserName = table.Column<string>(type: "Varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUser", x => new { x.ChatsChatId, x.UsersId, x.UsersUserName });
                    table.ForeignKey(
                        name: "FK_ChatUser_Chats_ChatsChatId",
                        column: x => x.ChatsChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUser_Users_UsersId_UsersUserName",
                        columns: x => new { x.UsersId, x.UsersUserName },
                        principalTable: "Users",
                        principalColumns: new[] { "Id", "UserName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUser_UsersId_UsersUserName",
                table: "ChatUser",
                columns: new[] { "UsersId", "UsersUserName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserChat",
                type: "varchar2(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)");
        }
    }
}
