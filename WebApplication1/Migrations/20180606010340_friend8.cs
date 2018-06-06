using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class friend8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteReviews",
                table: "RouteReviews");

            migrationBuilder.DropIndex(
                name: "IX_RouteReviews_RouteID",
                table: "RouteReviews");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "RouteReviews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteReviews",
                table: "RouteReviews",
                columns: new[] { "RouteID", "ReviewID" });

            migrationBuilder.CreateTable(
                name: "UserUsers",
                columns: table => new
                {
                    UserIdA = table.Column<int>(nullable: false),
                    UserIdB = table.Column<int>(nullable: false),
                    UserAID = table.Column<int>(nullable: true),
                    UserBID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUsers", x => new { x.UserIdA, x.UserIdB });
                    table.ForeignKey(
                        name: "FK_UserUsers_Users_UserAID",
                        column: x => x.UserAID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserUsers_Users_UserBID",
                        column: x => x.UserBID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUsers_UserAID",
                table: "UserUsers",
                column: "UserAID");

            migrationBuilder.CreateIndex(
                name: "IX_UserUsers_UserBID",
                table: "UserUsers",
                column: "UserBID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteReviews",
                table: "RouteReviews");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "RouteReviews",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteReviews",
                table: "RouteReviews",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteReviews_RouteID",
                table: "RouteReviews",
                column: "RouteID");
        }
    }
}
