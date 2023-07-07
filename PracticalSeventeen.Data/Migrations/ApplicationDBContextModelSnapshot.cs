﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticalSeventeen.Data.Models;

#nullable disable

namespace PracticalSeventeen.Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracticalSeventeen.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "User"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("PracticalSeventeen.Data.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Rajkot",
                            DOB = new DateTime(2002, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bhavin",
                            Gender = "M",
                            LastName = "Kareliya",
                            MobileNumber = "1231231231"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Rajkot",
                            DOB = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jil",
                            Gender = "M",
                            LastName = "Patel",
                            MobileNumber = "1231231231"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Rajkot",
                            DOB = new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Vipul",
                            Gender = "M",
                            LastName = "Kumar",
                            MobileNumber = "1231231231"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Rajkot",
                            DOB = new DateTime(2000, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jay",
                            Gender = "M",
                            LastName = "Gohel",
                            MobileNumber = "1231231231"
                        });
                });

            modelBuilder.Entity("PracticalSeventeen.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bhavin@gmail.com",
                            Firstname = "Bhavin",
                            LastName = "Kareliya",
                            Password = "123123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jil@gmail.com",
                            Firstname = "Jil",
                            LastName = "Patel",
                            Password = "123123"
                        },
                        new
                        {
                            Id = 3,
                            Email = "vipul@gmail.com",
                            Firstname = "Vipul",
                            LastName = "Kumar",
                            Password = "123123"
                        },
                        new
                        {
                            Id = 4,
                            Email = "abhi@gmail.com",
                            Firstname = "Abhi",
                            LastName = "Dasadiya",
                            Password = "123123"
                        },
                        new
                        {
                            Id = 5,
                            Email = "jay@gmail.com",
                            Firstname = "Jay",
                            LastName = "Gohel",
                            Password = "123123"
                        });
                });

            modelBuilder.Entity("PracticalSeventeen.Data.Models.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            RoleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            RoleId = 2,
                            UserId = 2
                        },
                        new
                        {
                            RoleId = 1,
                            UserId = 3
                        },
                        new
                        {
                            RoleId = 1,
                            UserId = 4
                        },
                        new
                        {
                            RoleId = 1,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("PracticalSeventeen.Data.Models.UserRole", b =>
                {
                    b.HasOne("PracticalSeventeen.Data.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticalSeventeen.Data.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PracticalSeventeen.Data.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PracticalSeventeen.Data.Models.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
