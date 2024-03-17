using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace your_bike_admin_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddYourBikeAPIWithImageCoorection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Iamge",
                table: "Bikes",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Bikes",
                newName: "Iamge");
        }
    }
}
