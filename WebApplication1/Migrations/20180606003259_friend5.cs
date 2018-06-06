using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class friend5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "FriendRequestsID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserID",
                table: "Users",
                newName: "IX_Users_FriendRequestsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_FriendRequestsID",
                table: "Users",
                column: "FriendRequestsID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_FriendRequestsID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "FriendRequestsID",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_FriendRequestsID",
                table: "Users",
                newName: "IX_Users_UserID");

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
