using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOnDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Departement_DepartementId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Ticket_TicketId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_AthureId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Category_CategoryId",
                table: "Ticket");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDataTime",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 16, 16, 7, 51, 556, DateTimeKind.Local).AddTicks(7256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 12, 31, 55, 54, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDataTime",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 16, 16, 7, 51, 553, DateTimeKind.Local).AddTicks(5786),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 12, 31, 55, 50, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Departement_DepartementId",
                table: "Category",
                column: "DepartementId",
                principalTable: "Departement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Ticket_TicketId",
                table: "Message",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_AthureId",
                table: "Message",
                column: "AthureId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Category_CategoryId",
                table: "Ticket",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Departement_DepartementId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Ticket_TicketId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_AthureId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Category_CategoryId",
                table: "Ticket");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDataTime",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 12, 31, 55, 54, DateTimeKind.Local).AddTicks(7159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 16, 16, 7, 51, 556, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDataTime",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 12, 31, 55, 50, DateTimeKind.Local).AddTicks(8865),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 16, 16, 7, 51, 553, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Departement_DepartementId",
                table: "Category",
                column: "DepartementId",
                principalTable: "Departement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Ticket_TicketId",
                table: "Message",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_AthureId",
                table: "Message",
                column: "AthureId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Category_CategoryId",
                table: "Ticket",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
