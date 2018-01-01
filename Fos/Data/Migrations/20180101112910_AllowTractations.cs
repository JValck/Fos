using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fos.Data.Migrations
{
    public partial class AllowTractations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DinnerTableId",
                table: "Orders",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DinnerTableId",
                table: "Orders",
                column: "DinnerTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DinnerTables_DinnerTableId",
                table: "Orders",
                column: "DinnerTableId",
                principalTable: "DinnerTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DinnerTables_DinnerTableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DinnerTableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DinnerTableId",
                table: "Orders");
        }
    }
}
