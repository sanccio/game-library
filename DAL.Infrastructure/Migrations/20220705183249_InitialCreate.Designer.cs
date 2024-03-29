﻿// <auto-generated />
using System;
using DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Infrastructure.Migrations
{
    [DbContext(typeof(GameLibraryDbContext))]
    [Migration("20220705183249_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DAL.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nickname")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "ecea73e7-0d95-4ea0-a416-e9defb3d6873",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d065c912-b83e-4cee-9a52-5d111c777db0",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Nickname = "Admin",
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELnIEGO63nGJYnDfe1IJj7LQZBTuVApuQ2YLzgSG+hw8xXfcMJm960qJIZ6ZRPpDrA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "afc4468a-a3ea-4538-9bbc-ec0ef369037b",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("DAL.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<string>("NicknameToReply")
                        .HasColumnType("text");

                    b.Property<int?>("ReplyToCommentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("GameId");

                    b.HasIndex("ReplyToCommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Developer")
                        .HasColumnType("text");

                    b.Property<string>("HeaderImage")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Rating")
                        .HasColumnType("text");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Trailer")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "An inadvertent brush with the mob thrusts cabdriver Tommy Angelo into the world of organized crime. Initially uneasy about falling in with the Salieri family, the rewards become too big to ignore.",
                            Developer = "Hangar 13",
                            HeaderImage = "https://i.ibb.co/C0JT8QG/mafia-definitive-edition.jpg",
                            Name = "Mafia: Definitive Edition",
                            Rating = "18",
                            ReleaseDate = new DateTime(2020, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Trailer = "https://www.youtube.com/embed/vfwfA_iTOng"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Assassin’s Creed® Unity is an action/adventure game set in the city of Paris during one of its darkest hours, the French Revolution. Take ownership of the story by customising Arno's equipement to make the experience unique to you, both visually and mechanically. In addition to an epic single-player experience, Assassin’s Creed Unity delivers the excitement of playing with up to three friends through online cooperative gameplay in specific missions. Throughout the game, take part in one of the most pivotal moments of French history in a compelling storyline and a breath-taking playground that brought you the city of lights of today.",
                            Developer = "Ubisoft",
                            HeaderImage = "https://i.ibb.co/sJ6ZJB8/assassin-s-creed-unity.jpg",
                            Name = "Assassin's Creed Unity",
                            Rating = "18",
                            ReleaseDate = new DateTime(2014, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Trailer = "https://www.youtube.com/embed/xzCEdSKMkdU"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Dynamic seasons change everything at the world’s greatest automotive festival. Go it alone or team up with others to explore beautiful and historic Britain in a shared open world. Collect, modify and drive over 450 cars. Race, stunt, create and explore – choose your own path to become a Horizon Superstar.",
                            Developer = "Playground Games",
                            HeaderImage = "https://i.ibb.co/Hz70tC8/forza-horizon-4.jpg",
                            Name = "Forza Horizon 4",
                            Rating = "3",
                            ReleaseDate = new DateTime(2021, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Trailer = "https://www.youtube.com/embed/5xy4n73WOMM"
                        });
                });

            modelBuilder.Entity("DAL.Entities.GameGenre", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsChanged")
                        .HasColumnType("boolean");

                    b.HasKey("GameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GameGenres");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            GenreId = 1,
                            Id = 0,
                            IsChanged = false
                        },
                        new
                        {
                            GameId = 1,
                            GenreId = 3,
                            Id = 0,
                            IsChanged = false
                        },
                        new
                        {
                            GameId = 1,
                            GenreId = 4,
                            Id = 0,
                            IsChanged = false
                        },
                        new
                        {
                            GameId = 2,
                            GenreId = 1,
                            Id = 0,
                            IsChanged = false
                        },
                        new
                        {
                            GameId = 2,
                            GenreId = 3,
                            Id = 0,
                            IsChanged = false
                        },
                        new
                        {
                            GameId = 3,
                            GenreId = 5,
                            Id = 0,
                            IsChanged = false
                        });
                });

            modelBuilder.Entity("DAL.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "An action game is a video game genre that emphasizes physical challenges, including hand–eye coordination and reaction-time. The genre includes a large variety of sub-genres, such as fighting games, beat 'em ups, shooter games, and platform games.",
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Description = "There are two major types of electronic strategy games: turn-based strategy (TBS) and real-time strategy (RTS). Although some TBS games have experimented with multiplayer support, the slow pace of waiting for each player to finish managing all of his or her resources and units has limited their appeal.",
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 3,
                            Description = "An adventure game is a video game in which the player assumes the role of a protagonist in an interactive story driven by exploration and/or puzzle-solving. The genre's focus on story allows it to draw heavily from other narrative-based media, literature and film, encompassing a wide variety of literary genres.",
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Crime is the genre that fictionalises crimes, their detection, criminals and their motives.",
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Racing games are a video game genre in which the player participates in a racing competition. They may be based on anything from real-world racing leagues to fantastical settings. They are distributed along a spectrum between more realistic racing simulations and more fantastical arcade-style racing games.",
                            Name = "Racing"
                        });
                });

            modelBuilder.Entity("DAL.Entities.UserCollection", b =>
                {
                    b.Property<int>("UserGameId")
                        .HasColumnType("integer");

                    b.Property<int>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("UserGameId", "CollectionId");

                    b.HasIndex("CollectionId");

                    b.ToTable("UserCollections");
                });

            modelBuilder.Entity("DAL.Entities.UserGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPassed")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("GameId");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "234cf25e-9848-4e7d-8c1c-fc43deaf19f5",
                            ConcurrencyStamp = "5ead6421-793b-4132-b588-c6b2c302da06",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "f341823e-bbd9-428d-b664-7bf70980019b",
                            ConcurrencyStamp = "3f19f833-ea12-401a-8a87-b8b75bc51ffd",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "ecea73e7-0d95-4ea0-a416-e9defb3d6873",
                            RoleId = "234cf25e-9848-4e7d-8c1c-fc43deaf19f5"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DAL.Entities.Collection", b =>
                {
                    b.HasOne("DAL.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Collections")
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("DAL.Entities.Comment", b =>
                {
                    b.HasOne("DAL.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("DAL.Entities.Game", "Game")
                        .WithMany("Comments")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Comment", "ReplyToComment")
                        .WithMany("Replies")
                        .HasForeignKey("ReplyToCommentId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Game");

                    b.Navigation("ReplyToComment");
                });

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.HasOne("DAL.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("DAL.Entities.GameGenre", b =>
                {
                    b.HasOne("DAL.Entities.Game", "Game")
                        .WithMany("GameGenres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Genre", "Genre")
                        .WithMany("GameGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("DAL.Entities.UserCollection", b =>
                {
                    b.HasOne("DAL.Entities.Collection", "Collection")
                        .WithMany("UserCollections")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.UserGame", "UserGame")
                        .WithMany("UserCollections")
                        .HasForeignKey("UserGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("UserGame");
                });

            modelBuilder.Entity("DAL.Entities.UserGame", b =>
                {
                    b.HasOne("DAL.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("DAL.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Collections");
                });

            modelBuilder.Entity("DAL.Entities.Collection", b =>
                {
                    b.Navigation("UserCollections");
                });

            modelBuilder.Entity("DAL.Entities.Comment", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("GameGenres");
                });

            modelBuilder.Entity("DAL.Entities.Genre", b =>
                {
                    b.Navigation("GameGenres");
                });

            modelBuilder.Entity("DAL.Entities.UserGame", b =>
                {
                    b.Navigation("UserCollections");
                });
#pragma warning restore 612, 618
        }
    }
}
