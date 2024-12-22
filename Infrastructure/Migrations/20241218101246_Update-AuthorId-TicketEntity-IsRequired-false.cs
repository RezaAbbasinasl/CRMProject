using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuthorIdTicketEntityIsRequiredfalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDataTime",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 18, 13, 42, 45, 744, DateTimeKind.Local).AddTicks(7544),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 16, 16, 7, 51, 556, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDataTime",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 18, 13, 42, 45, 741, DateTimeKind.Local).AddTicks(8858),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 16, 16, 7, 51, 553, DateTimeKind.Local).AddTicks(5786));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDataTime",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 16, 16, 7, 51, 556, DateTimeKind.Local).AddTicks(7256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 18, 13, 42, 45, 744, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDataTime",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 16, 16, 7, 51, 553, DateTimeKind.Local).AddTicks(5786),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 18, 13, 42, 45, 741, DateTimeKind.Local).AddTicks(8858));
        }
    }
}
