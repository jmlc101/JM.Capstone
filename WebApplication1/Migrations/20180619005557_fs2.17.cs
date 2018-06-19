using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class fs217 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIDA",
                table: "Friendships");

            migrationBuilder.DropColumn(
                name: "UserIDB",
                table: "Friendships");

            migrationBuilder.AddColumn<string>(
                name: "ScreenNameA",
                table: "Friendships",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenNameB",
                table: "Friendships",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenNameA",
                table: "Friendships");

            migrationBuilder.DropColumn(
                name: "ScreenNameB",
                table: "Friendships");

            migrationBuilder.AddColumn<int>(
                name: "UserIDA",
                table: "Friendships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIDB",
                table: "Friendships",
                nullable: false,
                defaultValue: 0);
        }
    }
}
