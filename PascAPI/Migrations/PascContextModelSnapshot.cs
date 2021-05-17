﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PASC.Models;

namespace PASC.Migrations
{
    [DbContext(typeof(PascContext))]
    partial class PascContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PASC.Models.Acceptance", b =>
                {
                    b.Property<int>("AcceptanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.HasKey("AcceptanceId");

                    b.ToTable("Acceptance");
                });

            modelBuilder.Entity("PASC.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("OptionId")
                        .HasColumnType("integer");

                    b.Property<string>("Other")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("AnswerId");

                    b.HasIndex("OptionId");

                    b.HasIndex("UserId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("PASC.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CenterId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("BuildingId");

                    b.HasIndex("CenterId");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("PASC.Models.Campi", b =>
                {
                    b.Property<int>("CampiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("CampiId");

                    b.ToTable("Campi");
                });

            modelBuilder.Entity("PASC.Models.Center", b =>
                {
                    b.Property<int>("CenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CampiId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("CenterId");

                    b.HasIndex("CampiId");

                    b.ToTable("Center");
                });

            modelBuilder.Entity("PASC.Models.Email", b =>
                {
                    b.Property<int>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("EmailId");

                    b.HasIndex("UserId");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("PASC.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("GenderId");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            GenderId = 1,
                            Name = "Masculine"
                        },
                        new
                        {
                            GenderId = 2,
                            Name = "Feminine"
                        },
                        new
                        {
                            GenderId = 3,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("PASC.Models.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("PASC.Models.Pass", b =>
                {
                    b.Property<int>("PassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Allowed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PassId");

                    b.HasIndex("UserId");

                    b.ToTable("Pass");
                });

            modelBuilder.Entity("PASC.Models.Phone", b =>
                {
                    b.Property<int>("PhoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PhoneId");

                    b.HasIndex("UserId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("PASC.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Multiple")
                        .HasColumnType("boolean");

                    b.Property<int>("QuestionCategoryId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuestionCategoryId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("PASC.Models.QuestionCategory", b =>
                {
                    b.Property<int>("QuestionCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("QuestionCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("QuestionCategory");
                });

            modelBuilder.Entity("PASC.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PASC.Models.Sector", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("UnityId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("SectorId");

                    b.HasIndex("UnityId");

                    b.HasIndex("UserId");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("PASC.Models.Unity", b =>
                {
                    b.Property<int>("UnityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("UnityId");

                    b.ToTable("Unity");
                });

            modelBuilder.Entity("PASC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Birth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<int?>("GenderId")
                        .HasColumnType("integer");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("GenderId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PASC.Models.UserAcceptance", b =>
                {
                    b.Property<int>("UserAcceptanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AcceptanceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserAcceptanceId");

                    b.HasIndex("AcceptanceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAcceptance");
                });

            modelBuilder.Entity("PASC.Models.UserBuilding", b =>
                {
                    b.Property<int>("UserBuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserBuildingId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBuilding");
                });

            modelBuilder.Entity("PASC.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int?>("RoleUserRoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleUserRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("PASC.Models.UserSector", b =>
                {
                    b.Property<int>("UserSectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserSectorId");

                    b.HasIndex("SectorId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSector");
                });

            modelBuilder.Entity("PASC.Models.Answer", b =>
                {
                    b.HasOne("PASC.Models.Option", "Option")
                        .WithMany("Answers")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PASC.Models.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASC.Models.Building", b =>
                {
                    b.HasOne("PASC.Models.Center", "Center")
                        .WithMany("Buildings")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Center");
                });

            modelBuilder.Entity("PASC.Models.Center", b =>
                {
                    b.HasOne("PASC.Models.Campi", "Campi")
                        .WithMany("Centers")
                        .HasForeignKey("CampiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campi");
                });

            modelBuilder.Entity("PASC.Models.Email", b =>
                {
                    b.HasOne("PASC.Models.User", "User")
                        .WithMany("Emails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASC.Models.Option", b =>
                {
                    b.HasOne("PASC.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("PASC.Models.Pass", b =>
                {
                    b.HasOne("PASC.Models.User", "User")
                        .WithMany("Passes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASC.Models.Phone", b =>
                {
                    b.HasOne("PASC.Models.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASC.Models.Question", b =>
                {
                    b.HasOne("PASC.Models.QuestionCategory", "QuestionCategory")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionCategory");
                });

            modelBuilder.Entity("PASC.Models.QuestionCategory", b =>
                {
                    b.HasOne("PASC.Models.QuestionCategory", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PASC.Models.Sector", b =>
                {
                    b.HasOne("PASC.Models.Unity", "Unity")
                        .WithMany("Sector")
                        .HasForeignKey("UnityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PASC.Models.User", null)
                        .WithMany("Sectors")
                        .HasForeignKey("UserId");

                    b.Navigation("Unity");
                });

            modelBuilder.Entity("PASC.Models.User", b =>
                {
                    b.HasOne("PASC.Models.Gender", "Gender")
                        .WithMany("users")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("PASC.Models.UserAcceptance", b =>
                {
                    b.HasOne("PASC.Models.Acceptance", "Acceptance")
                        .WithMany("UserAcceptances")
                        .HasForeignKey("AcceptanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PASC.Models.User", "User")
                        .WithMany("UserAcceptances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acceptance");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASC.Models.UserBuilding", b =>
                {
                    b.HasOne("PASC.Models.Building", "Building")
                        .WithMany("UserBuildings")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PASC.Models.User", "User")
                        .WithMany("UserBuildings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASC.Models.UserRole", b =>
                {
                    b.HasOne("PASC.Models.Role", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId");

                    b.HasOne("PASC.Models.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleUserRoleId");

                    b.HasOne("PASC.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASC.Models.UserSector", b =>
                {
                    b.HasOne("PASC.Models.Sector", "Sector")
                        .WithMany("UserSector")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PASC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sector");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PASC.Models.Acceptance", b =>
                {
                    b.Navigation("UserAcceptances");
                });

            modelBuilder.Entity("PASC.Models.Building", b =>
                {
                    b.Navigation("UserBuildings");
                });

            modelBuilder.Entity("PASC.Models.Campi", b =>
                {
                    b.Navigation("Centers");
                });

            modelBuilder.Entity("PASC.Models.Center", b =>
                {
                    b.Navigation("Buildings");
                });

            modelBuilder.Entity("PASC.Models.Gender", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("PASC.Models.Option", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("PASC.Models.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("PASC.Models.QuestionCategory", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("PASC.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("PASC.Models.Sector", b =>
                {
                    b.Navigation("UserSector");
                });

            modelBuilder.Entity("PASC.Models.Unity", b =>
                {
                    b.Navigation("Sector");
                });

            modelBuilder.Entity("PASC.Models.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Emails");

                    b.Navigation("Passes");

                    b.Navigation("Phones");

                    b.Navigation("Sectors");

                    b.Navigation("UserAcceptances");

                    b.Navigation("UserBuildings");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
