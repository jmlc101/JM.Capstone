using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class test2friendship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "FriendRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestingUserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserFriendRequests",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    RequestID = table.Column<int>(nullable: false),
                    FriendRequestID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriendRequests", x => new { x.UserID, x.RequestID });
                    table.ForeignKey(
                        name: "FK_UserFriendRequests_FriendRequest_FriendRequestID",
                        column: x => x.FriendRequestID,
                        principalTable: "FriendRequest",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriendRequests_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriendRequests_FriendRequestID",
                table: "UserFriendRequests",
                column: "FriendRequestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFriendRequests");

            migrationBuilder.DropTable(
                name: "FriendRequest");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserID",
                table: "Users",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
