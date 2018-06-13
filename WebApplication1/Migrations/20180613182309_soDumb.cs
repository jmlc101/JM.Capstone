using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class soDumb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriendRequests_FriendRequest_FriendRequestID",
                table: "UserFriendRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendRequest",
                table: "FriendRequest");

            migrationBuilder.RenameTable(
                name: "FriendRequest",
                newName: "FriendRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendRequests",
                table: "FriendRequests",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriendRequests_FriendRequests_FriendRequestID",
                table: "UserFriendRequests",
                column: "FriendRequestID",
                principalTable: "FriendRequests",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriendRequests_FriendRequests_FriendRequestID",
                table: "UserFriendRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendRequests",
                table: "FriendRequests");

            migrationBuilder.RenameTable(
                name: "FriendRequests",
                newName: "FriendRequest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendRequest",
                table: "FriendRequest",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriendRequests_FriendRequest_FriendRequestID",
                table: "UserFriendRequests",
                column: "FriendRequestID",
                principalTable: "FriendRequest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
