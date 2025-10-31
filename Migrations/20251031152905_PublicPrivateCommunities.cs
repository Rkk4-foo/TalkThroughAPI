using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalkThroughAPI.Migrations
{
    /// <inheritdoc />
    public partial class PublicPrivateCommunities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatsUsers_Chats_ChatId",
                table: "ChatsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatsUsers_Users_UserId_UserName",
                table: "ChatsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesUsers_Communities_CommunityId",
                table: "CommunitiesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesUsers_Users_UserId_UserName",
                table: "CommunitiesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserReceiverId_UserReceiverUsername",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCalls_Calls_CallId",
                table: "UsersCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCalls_Users_UserId_UserName",
                table: "UsersCalls");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatsUsers_Chats_ChatId",
                table: "ChatsUsers",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatsUsers_Users_UserId_UserName",
                table: "ChatsUsers",
                columns: new[] { "UserId", "UserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesUsers_Communities_CommunityId",
                table: "CommunitiesUsers",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "CommunityId");

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
                name: "FK_UsersCalls_Calls_CallId",
                table: "UsersCalls",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "CallId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCalls_Users_UserId_UserName",
                table: "UsersCalls",
                columns: new[] { "UserId", "UserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatsUsers_Chats_ChatId",
                table: "ChatsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatsUsers_Users_UserId_UserName",
                table: "ChatsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesUsers_Communities_CommunityId",
                table: "CommunitiesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunitiesUsers_Users_UserId_UserName",
                table: "CommunitiesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserReceiverId_UserReceiverUsername",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCalls_Calls_CallId",
                table: "UsersCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCalls_Users_UserId_UserName",
                table: "UsersCalls");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatsUsers_Chats_ChatId",
                table: "ChatsUsers",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatsUsers_Users_UserId_UserName",
                table: "ChatsUsers",
                columns: new[] { "UserId", "UserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunitiesUsers_Communities_CommunityId",
                table: "CommunitiesUsers",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "CommunityId",
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
                name: "FK_UsersCalls_Calls_CallId",
                table: "UsersCalls",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "CallId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCalls_Users_UserId_UserName",
                table: "UsersCalls",
                columns: new[] { "UserId", "UserName" },
                principalTable: "Users",
                principalColumns: new[] { "Id", "UserName" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
