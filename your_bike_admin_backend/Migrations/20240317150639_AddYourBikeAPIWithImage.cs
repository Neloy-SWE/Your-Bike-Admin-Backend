using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace your_bike_admin_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddYourBikeAPIWithImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Iamge",
                table: "Bikes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iamge",
                table: "Bikes");
        }
    }
}
