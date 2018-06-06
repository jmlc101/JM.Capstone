using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class test7friends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriendRequests_FriendRequest_FriendRequestID",
                table: "UserFriendRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriendRequests",
                table: "UserFriendRequests");

            migrationBuilder.DropColumn(
                name: "RequestID",
                table: "UserFriendRequests");

            migrationBuilder.AlterColumn<int>(
                name: "FriendRequestID",
                table: "UserFriendRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriendRequests",
                table: "UserFriendRequests",
                columns: new[] { "UserID", "FriendRequestID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriendRequests_FriendRequest_FriendRequestID",
                table: "UserFriendRequests",
                column: "FriendRequestID",
                principalTable: "FriendRequest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriendRequests_FriendRequest_FriendRequestID",
                table: "UserFriendRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriendRequests",
                table: "UserFriendRequests");

            migrationBuilder.AlterColumn<int>(
                name: "FriendRequestID",
                table: "UserFriendRequests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RequestID",
                table: "UserFriendRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriendRequests",
                table: "UserFriendRequests",
                columns: new[] { "UserID", "RequestID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriendRequests_FriendRequest_FriendRequestID",
                table: "UserFriendRequests",
                column: "FriendRequestID",
                principalTable: "FriendRequest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
