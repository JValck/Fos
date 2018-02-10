using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Fos.Data.Migrations
{
    public partial class RemoveKitchenOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitchenOrder");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "DishOrder",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "DishOrder",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.CreateIndex(
                name: "IX_DishOrder_StatusId",
                table: "DishOrder",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Statuses_StatusId",
                table: "DishOrder",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Statuses_StatusId",
                table: "DishOrder");

            migrationBuilder.DropIndex(
                name: "IX_DishOrder_StatusId",
                table: "DishOrder");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "DishOrder");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DishOrder");

            migrationBuilder.CreateTable(
                name: "KitchenOrder",
                columns: table => new
                {
                    KitchenId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitchenOrder", x => new { x.KitchenId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_KitchenOrder_Kitchens_KitchenId",
                        column: x => x.KitchenId,
                        principalTable: "Kitchens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitchenOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitchenOrder_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitchenOrder_OrderId",
                table: "KitchenOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_KitchenOrder_StatusId",
                table: "KitchenOrder",
                column: "StatusId");
        }
    }
}
