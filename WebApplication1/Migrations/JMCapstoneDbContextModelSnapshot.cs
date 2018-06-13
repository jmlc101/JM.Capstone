﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(JMCapstoneDbContext))]
    partial class JMCapstoneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.FriendRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RequestingUserID");

                    b.HasKey("ID");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("WebApplication1.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewBody");

                    b.Property<string>("ReviewByUser");

                    b.HasKey("ID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebApplication1.Models.Route", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedByUser");

                    b.Property<string>("Destination");

                    b.Property<string>("Origin");

                    b.Property<string>("RouteName");

                    b.Property<string>("Waypoints");

                    b.HasKey("ID");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("WebApplication1.Models.RouteReview", b =>
                {
                    b.Property<int>("RouteID");

                    b.Property<int>("ReviewID");

                    b.HasKey("RouteID", "ReviewID");

                    b.HasIndex("ReviewID");

                    b.ToTable("RouteReviews");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Email");

                    b.Property<string>("HashCode");

                    b.Property<DateTime>("ModificationTime");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("ScreenName");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.UserFriendRequest", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("FriendRequestID");

                    b.HasKey("UserID", "FriendRequestID");

                    b.HasIndex("FriendRequestID");

                    b.ToTable("UserFriendRequests");
                });

            modelBuilder.Entity("WebApplication1.Models.UserRoute", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("RouteID");

                    b.HasKey("UserID", "RouteID");

                    b.HasIndex("RouteID");

                    b.ToTable("UserRoutes");
                });

            modelBuilder.Entity("WebApplication1.Models.UserUser", b =>
                {
                    b.Property<int>("UserIdA");

                    b.Property<int>("UserIdB");

                    b.Property<int?>("UserAID");

                    b.Property<int?>("UserBID");

                    b.HasKey("UserIdA", "UserIdB");

                    b.HasIndex("UserAID");

                    b.HasIndex("UserBID");

                    b.ToTable("UserUsers");
                });

            modelBuilder.Entity("WebApplication1.Models.RouteReview", b =>
                {
                    b.HasOne("WebApplication1.Models.Review", "Review")
                        .WithMany("RouteReviews")
                        .HasForeignKey("ReviewID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.Route", "Route")
                        .WithMany("RouteReviews")
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.UserFriendRequest", b =>
                {
                    b.HasOne("WebApplication1.Models.FriendRequest", "FriendRequest")
                        .WithMany("UserFriendRequests")
                        .HasForeignKey("FriendRequestID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("UserFriendRequests")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.UserRoute", b =>
                {
                    b.HasOne("WebApplication1.Models.Route", "Route")
                        .WithMany("UserRoutes")
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany("UserRoutes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.UserUser", b =>
                {
                    b.HasOne("WebApplication1.Models.User", "UserA")
                        .WithMany()
                        .HasForeignKey("UserAID");

                    b.HasOne("WebApplication1.Models.User", "UserB")
                        .WithMany()
                        .HasForeignKey("UserBID");
                });
#pragma warning restore 612, 618
        }
    }
}
