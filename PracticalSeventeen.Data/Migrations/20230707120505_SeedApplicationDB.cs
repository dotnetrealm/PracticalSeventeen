using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PracticalSeventeen.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedApplicationDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DOB", "FirstName", "Gender", "LastName", "MiddleName", "varchar(10)" },
                values: new object[,]
                {
                    { 1, "Rajkot", new DateTime(2002, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhavin", "M", "Kareliya", null, "1231231231" },
                    { 2, "Rajkot", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jil", "M", "Patel", null, "1231231231" },
                    { 3, "Rajkot", new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vipul", "M", "Kumar", null, "1231231231" },
                    { 4, "Rajkot", new DateTime(2000, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jay", "M", "Gohel", null, "1231231231" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Firstname", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "bhavin@gmail.com", "Bhavin", "Kareliya", "123123" },
                    { 2, "jil@gmail.com", "Jil", "Patel", "123123" },
                    { 3, "vipul@gmail.com", "Vipul", "Kumar", "123123" },
                    { 4, "abhi@gmail.com", "Abhi", "Dasadiya", "123123" },
                    { 5, "jay@gmail.com", "Jay", "Gohel", "123123" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
