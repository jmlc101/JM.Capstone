using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class friendship2012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestKey",
                table: "Friendships",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_TestKey",
                table: "Friendships",
                column: "TestKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_TestKey",
                table: "Friendships",
                column: "TestKey",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_TestKey",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_TestKey",
                table: "Friendships");

            migrationBuilder.DropColumn(
                name: "TestKey",
                table: "Friendships");
        }
    }
}
