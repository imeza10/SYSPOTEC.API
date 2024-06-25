using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    AddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlPicProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImageSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: true),
                    AddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RolID",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractsUsers",
                columns: table => new
                {
                    ContractID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeContract = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UrlImageSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    DateIniContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsUsers", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK_ContractsUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolID", "AddAt", "Code", "Rol", "State" },
                values: new object[,]
                {
                    { new Guid("6f374c4b-3c62-4b47-a482-7d8c8068fd83"), new DateTime(2024, 6, 21, 2, 42, 37, 455, DateTimeKind.Local).AddTicks(3837), "CLI", "Cliente", 1 },
                    { new Guid("952d5976-edee-4324-84d9-edb861697346"), new DateTime(2024, 6, 21, 2, 42, 37, 455, DateTimeKind.Local).AddTicks(3819), "ADM", "Administrador", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AddAt", "Address", "Document", "Email", "Lastname", "Name", "Password", "Phone", "RolID", "State", "UrlImageSignature", "UrlPicProfile" },
                values: new object[] { new Guid("c4be9b11-201d-4edd-ae1c-7c30a08a87f2"), new DateTime(2024, 6, 21, 2, 42, 37, 457, DateTimeKind.Local).AddTicks(190), "St 56 Av 21", "12345", "admin@gmail.com", "System", "Admin", "7660f87046b2b25432960b3436962a53", "300 123 4567", new Guid("952d5976-edee-4324-84d9-edb861697346"), 1, "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractsUsers_UserID",
                table: "ContractsUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolID",
                table: "Users",
                column: "RolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractsUsers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
