using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fos.Data.Migrations
{
    public partial class SaveClientDefaultDinnerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinnerTableClient_Clients_ClientId",
                table: "DinnerTableClient");

            migrationBuilder.DropForeignKey(
                name: "FK_DinnerTableClient_DinnerTables_DinnerTableId",
                table: "DinnerTableClient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DinnerTableClient",
                table: "DinnerTableClient");

            migrationBuilder.RenameTable(
                name: "DinnerTableClient",
                newName: "DinnerTableClients");

            migrationBuilder.RenameIndex(
                name: "IX_DinnerTableClient_DinnerTableId",
                table: "DinnerTableClients",
                newName: "IX_DinnerTableClients_DinnerTableId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DinnerTableClients",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrent",
                table: "DinnerTableClients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DinnerTableClients",
                table: "DinnerTableClients",
                columns: new[] { "ClientId", "DinnerTableId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DinnerTableClients_Clients_ClientId",
                table: "DinnerTableClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinnerTableClients_DinnerTables_DinnerTableId",
                table: "DinnerTableClients",
                column: "DinnerTableId",
                principalTable: "DinnerTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinnerTableClients_Clients_ClientId",
                table: "DinnerTableClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DinnerTableClients_DinnerTables_DinnerTableId",
                table: "DinnerTableClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DinnerTableClients",
                table: "DinnerTableClients");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DinnerTableClients");

            migrationBuilder.DropColumn(
                name: "IsCurrent",
                table: "DinnerTableClients");

            migrationBuilder.RenameTable(
                name: "DinnerTableClients",
                newName: "DinnerTableClient");

            migrationBuilder.RenameIndex(
                name: "IX_DinnerTableClients_DinnerTableId",
                table: "DinnerTableClient",
                newName: "IX_DinnerTableClient_DinnerTableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DinnerTableClient",
                table: "DinnerTableClient",
                columns: new[] { "ClientId", "DinnerTableId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DinnerTableClient_Clients_ClientId",
                table: "DinnerTableClient",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinnerTableClient_DinnerTables_DinnerTableId",
                table: "DinnerTableClient",
                column: "DinnerTableId",
                principalTable: "DinnerTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
