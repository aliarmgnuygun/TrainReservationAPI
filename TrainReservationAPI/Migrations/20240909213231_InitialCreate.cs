﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainReservationAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wagons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    OccupiedSeats = table.Column<int>(type: "int", nullable: false),
                    TrainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wagons_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Capital Express" });

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "East Coast Line" });

            migrationBuilder.CreateIndex(
                name: "IX_Wagons_TrainId",
                table: "Wagons",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wagons");

            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
