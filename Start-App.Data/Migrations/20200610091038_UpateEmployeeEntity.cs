using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Start_App.Data.Migrations
{
    public partial class UpateEmployeeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("1861341e-b42b-410c-ae21-cf11f36fc574"),
                column: "EmployeeName",
                value: "Not Man");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4b501cb3-d168-4cc0-b375-48fb33f318a4"),
                column: "EmployeeName",
                value: "Nick Carter");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("679dfd33-32e4-4393-b061-f7abb8956f53"),
                column: "EmployeeName",
                value: "卡里");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("72457e73-ea34-4e02-b575-8d384e82a481"),
                column: "EmployeeName",
                value: "Mary King");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7644b71d-d74e-43e2-ac32-8cbadd7b1c3a"),
                column: "EmployeeName",
                value: "Kevin Richardson");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7eaa532c-1be5-472c-a738-94fd26e5fad6"),
                column: "EmployeeName",
                value: "Vince Carter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("1861341e-b42b-410c-ae21-cf11f36fc574"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Not", "Man" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4b501cb3-d168-4cc0-b375-48fb33f318a4"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Nick", "Carter" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("679dfd33-32e4-4393-b061-f7abb8956f53"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "卡", "里" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("72457e73-ea34-4e02-b575-8d384e82a481"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Mary", "King" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7644b71d-d74e-43e2-ac32-8cbadd7b1c3a"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Kevin", "Richardson" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7eaa532c-1be5-472c-a738-94fd26e5fad6"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Vince", "Carter" });
        }
    }
}
