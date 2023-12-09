﻿// <auto-generated />
using System;
using Final_WebApplication_Admin.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Final_WebApplication_Admin.Migrations
{
    [DbContext(typeof(SiteDBcontext))]
    [Migration("20231101124410_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppUserTraining", b =>
                {
                    b.Property<int>("TrainingUsersUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserTrainingstId")
                        .HasColumnType("int");

                    b.HasKey("TrainingUsersUserId", "UserTrainingstId");

                    b.HasIndex("UserTrainingstId");

                    b.ToTable("AppUserTraining");
                });

            modelBuilder.Entity("Final_WebApplication_Admin.Models.AppUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Final_WebApplication_Admin.Models.Training", b =>
                {
                    b.Property<int>("tId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tId"), 1L, 1);

                    b.Property<int?>("TrainingCategoryCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tCategory")
                        .HasColumnType("int");

                    b.Property<string>("tDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tId");

                    b.HasIndex("TrainingCategoryCategoryID");

                    b.ToTable("trainings");
                });

            modelBuilder.Entity("Final_WebApplication_Admin.Models.TrainingCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("category");
                });

            modelBuilder.Entity("Final_WebApplication_Admin.Models.TrainingGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("trainingID")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("trainingID");

                    b.ToTable("trainingGalleries");
                });

            modelBuilder.Entity("Final_WebApplication_Admin.Models.UserTraining", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("TrainingID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserTrainings");
                });

            modelBuilder.Entity("AppUserTraining", b =>
                {
                    b.HasOne("Final_WebApplication_Admin.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("TrainingUsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Final_WebApplication_Admin.Models.Training", null)
                        .WithMany()
                        .HasForeignKey("UserTrainingstId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Final_WebApplication_Admin.Models.Training", b =>
                {
                    b.HasOne("Final_WebApplication_Admin.Models.TrainingCategory", null)
                        .WithMany("Trainings")
                        .HasForeignKey("TrainingCategoryCategoryID");
                });

            modelBuilder.Entity("Final_WebApplication_Admin.Models.TrainingGallery", b =>
                {
                    b.HasOne("Final_WebApplication_Admin.Models.Training", null)
                        .WithMany("ImageUrls")
                        .HasForeignKey("trainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Final_WebApplication_Admin.Models.Training", b =>
                {
                    b.Navigation("ImageUrls");
                });

            modelBuilder.Entity("Final_WebApplication_Admin.Models.TrainingCategory", b =>
                {
                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
