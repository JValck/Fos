using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fos.Data.Migrations
{
    public partial class LinkStatusToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Dishes_DishId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Orders_OrderId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Statuses_StatusId",
                table: "DishOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder");

            migrationBuilder.DropIndex(
                name: "IX_DishOrder_StatusId",
                table: "DishOrder");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "DishOrder");

            migrationBuilder.RenameTable(
                name: "DishOrder",
                newName: "DishOrders");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrder_OrderId",
                table: "DishOrders",
                newName: "IX_DishOrders_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Orders",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders",
                columns: new[] { "DishId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Orders_OrderId",
                table: "DishOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Statuses_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Dishes_DishId",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Orders_OrderId",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Statuses_StatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "DishOrders",
                newName: "DishOrder");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrders_OrderId",
                table: "DishOrder",
                newName: "IX_DishOrder_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "DishOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder",
                columns: new[] { "DishId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_DishOrder_StatusId",
                table: "DishOrder",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Dishes_DishId",
                table: "DishOrder",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Orders_OrderId",
                table: "DishOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Statuses_StatusId",
                table: "DishOrder",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
