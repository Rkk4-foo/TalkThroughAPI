using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalkThroughAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedCoumpoundPkToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatsUsers_Users_UserId",
                table: "ChatsUsers");

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
                name: "FK_UsersCalls_Users_UserId",
                table: "UsersCalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCalls",
                table: "UsersCalls");

            migrationBuilder.DropIndex(
                name: "IX_UsersCalls_UserId",
                table: "UsersCalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserReceiverId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommunitiesUsers",
                table: "CommunitiesUsers");

            migrationBuilder.DropIndex(
                name: "IX_CommunitiesUsers_UserId",
                table: "CommunitiesUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatsUsers",
                table: "ChatsUsers");

            migrationBuilder.DropIndex(
                name: "IX_ChatsUsers_UserId",
                table: "ChatsUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UsersCalls",
                type: "Varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "Varchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserSenderUsername",
                table: "Friends",
                type: "Varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserReceiverUsername",
                table: "Friends",
                type: "Varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CommunitiesUsers",
                type: "Varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ChatsUsers",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCalls",
                table: "UsersCalls",
                columns: new[] { "CallId", "UserId", "UserName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                columns: new[] { "Id", "UserName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                columns: new[] { "UserSenderId", "UserReceiverId", "UserSenderUsername", "UserReceiverUsername" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunitiesUsers",
                table: "CommunitiesUsers",
                columns: new[] { "UserId", "UserName", "CommunityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatsUsers",
                table: "ChatsUsers",
                columns: new[] { "ChatId", "UserId", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersCalls_UserId_UserName",
                table: "UsersCalls",
                columns: new[] { "UserId", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserReceiverId_UserReceiverUsername",
                table: "Friends",
                columns: new[] { "UserReceiverId", "UserReceiverUsername" });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserSenderId_UserSenderUsername",
                table: "Friends",
                columns: new[] { "UserSenderId", "UserSenderUsername" });

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesUsers_CommunityId",
                table: "CommunitiesUsers",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatsUsers_UserId_UserName",
                table: "ChatsUsers",
                columns: new[] { "UserId", "UserName" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatsUsers_Users_UserId_UserName",
                table: "ChatsUsers",
                columns: new[] { "UserId", "UserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesUsers_Users_UserId_UserName",
                table: "CommunitiesUsers",
                columns: new[] { "UserId", "UserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserReceiverId_UserReceiverUsername",
                table: "Friends",
                columns: new[] { "UserReceiverId", "UserReceiverUsername" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserSenderId_UserSenderUsername",
                table: "Friends",
                columns: new[] { "UserSenderId", "UserSenderUsername" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCalls_Users_UserId_UserName",
                table: "UsersCalls",
                columns: new[] { "UserId", "UserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatsUsers_Users_UserId_UserName",
                table: "ChatsUsers");

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
                name: "FK_UsersCalls_Users_UserId_UserName",
                table: "UsersCalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCalls",
                table: "UsersCalls");

            migrationBuilder.DropIndex(
                name: "IX_UsersCalls_UserId_UserName",
                table: "UsersCalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

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

            migrationBuilder.DropIndex(
                name: "IX_CommunitiesUsers_CommunityId",
                table: "CommunitiesUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatsUsers",
                table: "ChatsUsers");

            migrationBuilder.DropIndex(
                name: "IX_ChatsUsers_UserId_UserName",
                table: "ChatsUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UsersCalls");

            migrationBuilder.DropColumn(
                name: "UserSenderUsername",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "UserReceiverUsername",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CommunitiesUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ChatsUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(40)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCalls",
                table: "UsersCalls",
                columns: new[] { "CallId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                columns: new[] { "UserSenderId", "UserReceiverId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommunitiesUsers",
                table: "CommunitiesUsers",
                columns: new[] { "CommunityId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatsUsers",
                table: "ChatsUsers",
                columns: new[] { "ChatId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersCalls_UserId",
                table: "UsersCalls",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserReceiverId",
                table: "Friends",
                column: "UserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesUsers_UserId",
                table: "CommunitiesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatsUsers_UserId",
                table: "ChatsUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatsUsers_Users_UserId",
                table: "ChatsUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesUsers_Users_UserId",
                table: "CommunitiesUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserReceiverId",
                table: "Friends",
                column: "UserReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserSenderId",
                table: "Friends",
                column: "UserSenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCalls_Users_UserId",
                table: "UsersCalls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
