using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace your_bike_admin_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddBikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CC = table.Column<double>(type: "float", nullable: false),
                    Gears = table.Column<int>(type: "int", nullable: false),
                    MaxPower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxTorque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelTankCapacity = table.Column<double>(type: "float", nullable: false),
                    EngineOilCapacity = table.Column<double>(type: "float", nullable: false),
                    SeatHeight = table.Column<double>(type: "float", nullable: false),
                    FrontSuspension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RearSuspension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontBreak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RearBreak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontWheel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RearWheel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontTyre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RearTyre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");
        }
    }
}
