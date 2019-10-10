﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebLaserTag.Data;

namespace WebLaserTag.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("WebLaserTag.Models.Game", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ended");

                    b.Property<double>("FlagX");

                    b.Property<double>("FlagY");

                    b.Property<string>("HostName");

                    b.Property<int>("Password");

                    b.Property<double>("StartX");

                    b.Property<double>("StartY");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WebLaserTag.Models.Player", b =>
                {
                    b.Property<string>("MacAddress")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GameId");

                    b.Property<string>("Name");

                    b.HasKey("MacAddress");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("WebLaserTag.Models.PlayerData", b =>
                {
                    b.Property<string>("PlayerMacAddress")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentState");

                    b.Property<bool>("HasFlag");

                    b.Property<string>("PlayerMacAddress1");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<double>("XGeo");

                    b.Property<double>("YGeo");

                    b.HasKey("PlayerMacAddress");

                    b.HasIndex("PlayerMacAddress1");

                    b.ToTable("PlayersData");
                });

            modelBuilder.Entity("WebLaserTag.Models.Player", b =>
                {
                    b.HasOne("WebLaserTag.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("WebLaserTag.Models.PlayerData", b =>
                {
                    b.HasOne("WebLaserTag.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerMacAddress1");
                });
#pragma warning restore 612, 618
        }
    }
}
