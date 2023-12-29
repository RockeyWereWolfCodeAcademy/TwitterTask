using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.DAL.Migrations
{
    public partial class ChangedCreatedAtColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 29, 12, 25, 37, 157, DateTimeKind.Local).AddTicks(6682));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 29, 12, 25, 37, 157, DateTimeKind.Local).AddTicks(6682),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
