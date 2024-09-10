using Microsoft.EntityFrameworkCore.Migrations;

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
                    TrainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wagons_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Capital Express" },
                    { 2, "East Coast Line" }
                });

            migrationBuilder.InsertData(
                table: "Wagons",
                columns: new[] { "Id", "Capacity", "Name", "OccupiedSeats", "TrainId" },
                values: new object[,]
                {
                    { 1, 100, "Wagon 1", 68, null },
                    { 2, 90, "Wagon 2", 50, null },
                    { 3, 80, "Wagon 1", 60, null },
                    { 4, 75, "Wagon 2", 70, null }
                });

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
