using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalkThroughAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserNameIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Users_UsersId_UsersUserName",
                table: "ChatUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesUsers_Users_UserId_UserName",
                table: "CommunitiesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserReceiverId_UserReceiverUsername",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserSenderId_UserSenderUsername",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId_SenderUserName",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_Users_UserId_UserName",
                table: "UserChat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat");

            migrationBuilder.DropIndex(
                name: "IX_UserChat_UserId_UserName",
                table: "UserChat");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId_SenderUserName",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserReceiverId_UserReceiverUsername",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserSenderId_UserSenderUsername",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunitiesUsers",
                table: "CommunitiesUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatUser",
                table: "ChatUser");

            migrationBuilder.DropIndex(
                name: "IX_ChatUser_UsersId_UsersUserName",
                table: "ChatUser");

            migrationBuilder.DropColumn(
                name: "SenderUserName",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UsersUserName",
                table: "ChatUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserChat",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(40)");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "Varchar(40)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "CommunitiesUsers",
                type: "Varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(40)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat",
                columns: new[] { "ChatId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                columns: new[] { "UserSenderId", "UserReceiverId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunitiesUsers",
                table: "CommunitiesUsers",
                columns: new[] { "UserId", "CommunityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatUser",
                table: "ChatUser",
                columns: new[] { "ChatsChatId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserChat_UserId",
                table: "UserChat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserReceiverId",
                table: "Friends",
                column: "UserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUser_UsersId",
                table: "ChatUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Users_UsersId",
                table: "ChatUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesUsers_Users_UserId",
                table: "CommunitiesUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserReceiverId",
                table: "Friends",
                column: "UserReceiverId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserSenderId",
                table: "Friends",
                column: "UserSenderId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_Users_UserId",
                table: "UserChat",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Users_UsersId",
                table: "ChatUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesUsers_Users_UserId",
                table: "CommunitiesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserReceiverId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserSenderId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChat_Users_UserId",
                table: "UserChat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat");

            migrationBuilder.DropIndex(
                name: "IX_UserChat_UserId",
                table: "UserChat");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserReceiverId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunitiesUsers",
                table: "CommunitiesUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatUser",
                table: "ChatUser");

            migrationBuilder.DropIndex(
                name: "IX_ChatUser_UsersId",
                table: "ChatUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserChat",
                type: "Varchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "Varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(40)");

            migrationBuilder.AddColumn<string>(
                name: "SenderUserName",
                table: "Messages",
                type: "Varchar(40)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "CommunitiesUsers",
                type: "Varchar(40)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Varchar(40)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersUserName",
                table: "ChatUser",
                type: "Varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                columns: new[] { "Id", "UserName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChat",
                table: "UserChat",
                columns: new[] { "ChatId", "UserId", "UserName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                columns: new[] { "UserSenderId", "UserReceiverId", "UserSenderUsername", "UserReceiverUsername" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunitiesUsers",
                table: "CommunitiesUsers",
                columns: new[] { "UserId", "UserName", "CommunityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatUser",
                table: "ChatUser",
                columns: new[] { "ChatsChatId", "UsersId", "UsersUserName" });

            migrationBuilder.CreateIndex(
                name: "IX_UserChat_UserId_UserName",
                table: "UserChat",
                columns: new[] { "UserId", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId_SenderUserName",
                table: "Messages",
                columns: new[] { "SenderId", "SenderUserName" });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserReceiverId_UserReceiverUsername",
                table: "Friends",
                columns: new[] { "UserReceiverId", "UserReceiverUsername" });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserSenderId_UserSenderUsername",
                table: "Friends",
                columns: new[] { "UserSenderId", "UserSenderUsername" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUser_UsersId_UsersUserName",
                table: "ChatUser",
                columns: new[] { "UsersId", "UsersUserName" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Users_UsersId_UsersUserName",
                table: "ChatUser",
                columns: new[] { "UsersId", "UsersUserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesUsers_Users_UserId_UserName",
                table: "CommunitiesUsers",
                columns: new[] { "UserId", "UserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserReceiverId_UserReceiverUsername",
                table: "Friends",
                columns: new[] { "UserReceiverId", "UserReceiverUsername" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserSenderId_UserSenderUsername",
                table: "Friends",
                columns: new[] { "UserSenderId", "UserSenderUsername" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId_SenderUserName",
                table: "Messages",
                columns: new[] { "SenderId", "SenderUserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserChat_Users_UserId_UserName",
                table: "UserChat",
                columns: new[] { "UserId", "UserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" });
        }
    }
}
