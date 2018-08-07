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

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("RequestedUserID");

                    b.Property<string>("RequestedUserScreenName");

                    b.Property<int>("RequestingUserID");

                    b.Property<string>("RequestingUserScreenName");

                    b.HasKey("ID");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("WebApplication1.Models.Friendships", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ScreenNameA");

                    b.Property<string>("ScreenNameB");

                    b.HasKey("ID");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("WebApplication1.Models.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("ReceiverID");

                    b.Property<string>("ReceiverScreenName");

                    b.Property<string>("SenderScreenName");

                    b.Property<int>("SendersID");

                    b.Property<bool>("Viewed");

                    b.HasKey("ID");

                    b.ToTable("Messages");
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

                    b.Property<string>("BriefDescription");

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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ReviewID");

                    b.Property<int>("RouteID");

                    b.HasKey("ID");

                    b.HasIndex("ReviewID");

                    b.HasIndex("RouteID");

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

                    b.Property<int>("ReviewsMade");

                    b.Property<string>("ScreenName");

                    b.Property<int>("TrailsBlazed");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.UserRoute", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("RouteID");

                    b.HasKey("UserID", "RouteID");

                    b.HasIndex("RouteID");

                    b.ToTable("UserRoutes");
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
#pragma warning restore 612, 618
        }
    }
}
