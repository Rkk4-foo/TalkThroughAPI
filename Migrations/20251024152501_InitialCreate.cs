using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalkThroughAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    CallId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    CallStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.CallId);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    ChatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ChatCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                });

            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    CommunityId = table.Column<string>(type: "varchar(40)", nullable: false),
                    CommunityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.CommunityId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageSentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "Varchar(40)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserProfilePicture = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    AccountCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunitiesChats",
                columns: table => new
                {
                    IdChat = table.Column<string>(type: "Varchar(40)", nullable: false),
                    IdCommunity = table.Column<string>(type: "Varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunitiesChats", x => new { x.IdChat, x.IdCommunity });
                    table.ForeignKey(
                        name: "FK_CommunitiesChats_Chats_IdChat",
                        column: x => x.IdChat,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunitiesChats_Communities_IdCommunity",
                        column: x => x.IdCommunity,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessagesChats",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    MessageId = table.Column<string>(type: "Varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesChats", x => new { x.ChatId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_MessagesChats_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessagesChats_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatsUsers",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "varchar(40)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatsUsers", x => new { x.ChatId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ChatsUsers_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatsUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunitiesUsers",
                columns: table => new
                {
                    CommunityId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    UserId = table.Column<string>(type: "Varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunitiesUsers", x => new { x.CommunityId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CommunitiesUsers_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunitiesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    UserSenderId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    UserReceiverId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    RequestAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.UserSenderId, x.UserReceiverId });
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserReceiverId",
                        column: x => x.UserReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserSenderId",
                        column: x => x.UserSenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersCalls",
                columns: table => new
                {
                    CallId = table.Column<string>(type: "Varchar(40)", nullable: false),
                    UserId = table.Column<string>(type: "Varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCalls", x => new { x.CallId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersCalls_Calls_CallId",
                        column: x => x.CallId,
                        principalTable: "Calls",
                        principalColumn: "CallId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersCalls_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatsUsers_UserId",
                table: "ChatsUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesChats_IdCommunity",
                table: "CommunitiesChats",
                column: "IdCommunity");

            migrationBuilder.CreateIndex(
                name: "IX_CommunitiesUsers_UserId",
                table: "CommunitiesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserReceiverId",
                table: "Friends",
                column: "UserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesChats_MessageId",
                table: "MessagesChats",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCalls_UserId",
                table: "UsersCalls",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatsUsers");

            migrationBuilder.DropTable(
                name: "CommunitiesChats");

            migrationBuilder.DropTable(
                name: "CommunitiesUsers");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "MessagesChats");

            migrationBuilder.DropTable(
                name: "UsersCalls");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
