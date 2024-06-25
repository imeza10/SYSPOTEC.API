﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240621074237_Initialize")]
    partial class Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.ContractsUsers", b =>
                {
                    b.Property<Guid>("ContractID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinContract")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateIniContract")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<Guid>("TypeContract")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UrlImageSignature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ContractID");

                    b.HasIndex("UserID");

                    b.ToTable("ContractsUsers");
                });

            modelBuilder.Entity("Domain.Roles", b =>
                {
                    b.Property<Guid>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AddAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("RolID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RolID = new Guid("952d5976-edee-4324-84d9-edb861697346"),
                            AddAt = new DateTime(2024, 6, 21, 2, 42, 37, 455, DateTimeKind.Local).AddTicks(3819),
                            Code = "ADM",
                            Rol = "Administrador",
                            State = 1
                        },
                        new
                        {
                            RolID = new Guid("6f374c4b-3c62-4b47-a482-7d8c8068fd83"),
                            AddAt = new DateTime(2024, 6, 21, 2, 42, 37, 455, DateTimeKind.Local).AddTicks(3837),
                            Code = "CLI",
                            Rol = "Cliente",
                            State = 1
                        });
                });

            modelBuilder.Entity("Domain.Users", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AddAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RolID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<string>("UrlImageSignature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlPicProfile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("RolID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = new Guid("c4be9b11-201d-4edd-ae1c-7c30a08a87f2"),
                            AddAt = new DateTime(2024, 6, 21, 2, 42, 37, 457, DateTimeKind.Local).AddTicks(190),
                            Address = "St 56 Av 21",
                            Document = "12345",
                            Email = "admin@gmail.com",
                            Lastname = "System",
                            Name = "Admin",
                            Password = "7660f87046b2b25432960b3436962a53",
                            Phone = "300 123 4567",
                            RolID = new Guid("952d5976-edee-4324-84d9-edb861697346"),
                            State = 1,
                            UrlImageSignature = "",
                            UrlPicProfile = ""
                        });
                });

            modelBuilder.Entity("Domain.ContractsUsers", b =>
                {
                    b.HasOne("Domain.Users", "User")
                        .WithMany("ContractsUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Users", b =>
                {
                    b.HasOne("Domain.Roles", "RolesNavigation")
                        .WithMany("Users")
                        .HasForeignKey("RolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RolesNavigation");
                });

            modelBuilder.Entity("Domain.Roles", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Users", b =>
                {
                    b.Navigation("ContractsUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
