﻿// <auto-generated />
using System;
using Final_Web_Application.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Final_Web_Application.Migrations
{
    [DbContext(typeof(SiteDBcontext))]
    partial class SiteDBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Final_Web_Application.Models.AppUser", b =>
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

            modelBuilder.Entity("Final_Web_Application.Models.Training", b =>
                {
                    b.Property<int>("tId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tId"), 1L, 1);

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tId");

                    b.ToTable("trainings");
                });

            modelBuilder.Entity("Final_Web_Application.Models.TrainingGallery", b =>
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

            modelBuilder.Entity("Final_Web_Application.Models.UserTraining", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AppUserUserId")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingtId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserUserId");

                    b.HasIndex("TrainingtId");

                    b.ToTable("UserTrainings");
                });

            modelBuilder.Entity("Final_Web_Application.Models.TrainingGallery", b =>
                {
                    b.HasOne("Final_Web_Application.Models.Training", null)
                        .WithMany("ImageUrls")
                        .HasForeignKey("trainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Final_Web_Application.Models.UserTraining", b =>
                {
                    b.HasOne("Final_Web_Application.Models.AppUser", null)
                        .WithMany("TrainingUsers")
                        .HasForeignKey("AppUserUserId");

                    b.HasOne("Final_Web_Application.Models.Training", null)
                        .WithMany("TrainingUsers")
                        .HasForeignKey("TrainingtId");
                });

            modelBuilder.Entity("Final_Web_Application.Models.AppUser", b =>
                {
                    b.Navigation("TrainingUsers");
                });

            modelBuilder.Entity("Final_Web_Application.Models.Training", b =>
                {
                    b.Navigation("ImageUrls");

                    b.Navigation("TrainingUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
