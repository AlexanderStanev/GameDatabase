﻿// <auto-generated />
using System;
using GamesDatabase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GamesDatabase.Data.Migrations
{
    [DbContext(typeof(GamesDatabaseContext))]
    [Migration("20201104003906_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GamesDatabase.Data.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Developer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.Property<string>("GameEngineId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("OfficialWebsite")
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("GameEngineId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.GameEngine", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("GameEngines");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Image", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("GameId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<int>("ImageType")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Platform", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Publisher", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Release", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("GameId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("PlatformId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlatformId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GameId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Video", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("GameId")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)")
                        .HasMaxLength(36);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Developer", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.Game", null)
                        .WithMany("Developers")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Game", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.GameEngine", "GameEngine")
                        .WithMany()
                        .HasForeignKey("GameEngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Genre", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.Game", null)
                        .WithMany("Genres")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Image", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.Game", "Game")
                        .WithMany("Images")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Platform", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.Game", null)
                        .WithMany("Platforms")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Publisher", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.Game", null)
                        .WithMany("Publishers")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Release", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.Game", "Game")
                        .WithMany("Releases")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesDatabase.Data.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Review", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("GamesDatabase.Data.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Tag", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.Game", null)
                        .WithMany("Tags")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("GamesDatabase.Data.Models.Video", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.Game", "Game")
                        .WithMany("Videos")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesDatabase.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GamesDatabase.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}