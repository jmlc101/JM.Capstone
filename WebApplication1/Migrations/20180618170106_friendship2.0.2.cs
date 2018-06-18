using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class friendship202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_RequestedID",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_RequestorID",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteReviews_Reviews_ReviewID",
                table: "RouteReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteReviews_Routes_RouteID",
                table: "RouteReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutes_Routes_RouteID",
                table: "UserRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutes_Users_UserID",
                table: "UserRoutes");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_RequestedID",
                table: "Friendships",
                column: "RequestedID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_RequestorID",
                table: "Friendships",
                column: "RequestorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteReviews_Reviews_ReviewID",
                table: "RouteReviews",
                column: "ReviewID",
                principalTable: "Reviews",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteReviews_Routes_RouteID",
                table: "RouteReviews",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutes_Routes_RouteID",
                table: "UserRoutes",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutes_Users_UserID",
                table: "UserRoutes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_RequestedID",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_RequestorID",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteReviews_Reviews_ReviewID",
                table: "RouteReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteReviews_Routes_RouteID",
                table: "RouteReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutes_Routes_RouteID",
                table: "UserRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoutes_Users_UserID",
                table: "UserRoutes");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_RequestedID",
                table: "Friendships",
                column: "RequestedID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_RequestorID",
                table: "Friendships",
                column: "RequestorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteReviews_Reviews_ReviewID",
                table: "RouteReviews",
                column: "ReviewID",
                principalTable: "Reviews",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteReviews_Routes_RouteID",
                table: "RouteReviews",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutes_Routes_RouteID",
                table: "UserRoutes",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoutes_Users_UserID",
                table: "UserRoutes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
