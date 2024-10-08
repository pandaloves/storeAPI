using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace storeAPI.Migrations
{
    /// <inheritdoc />
    public partial class SecondChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHfamFahLTBWDTLUKhzs6wYtrsZd5HHjmTtA&s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.bbcgoodfood.com%2Fhowto%2Fguide%2Fhealth-benefits-green-tea&psig=AOvVaw29r9VrQijAyTljOgIss4K5&ust=1726421156275000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCNjn8Zj6wogDFQAAAAAdAAAAABAE");
        }
    }
}
