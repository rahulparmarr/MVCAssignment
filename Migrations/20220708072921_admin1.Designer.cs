﻿// <auto-generated />
using System;
using MVCAssignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCAssignment.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220708072921_admin1")]
    partial class admin1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCAssignment.Models.EventDetails", b =>
                {
                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InviteByEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartTime")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfEvent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Title");

                    b.HasIndex("Email");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("MVCAssignment.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Email = "myadmin@bookevents.com",
                            FullName = "Admin",
                            Password = "@admin"
                        });
                });

            modelBuilder.Entity("MVCAssignment.Models.EventDetails", b =>
                {
                    b.HasOne("MVCAssignment.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("Email");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
