using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace storeAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caffeine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.bbcgoodfood.com%2Fhowto%2Fguide%2Fhealth-benefits-green-tea&psig=AOvVaw29r9VrQijAyTljOgIss4K5&ust=1726421156275000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCNjn8Zj6wogDFQAAAAAdAAAAABAE", "Grönt te" },
                    { 2, "https://www.healthifyme.com/blog/wp-content/uploads/2020/02/Black-Tea-2-1.jpg", "Svart te" },
                    { 3, "https://kahlstkh.se/wp-content/uploads/2018/03/te-rooibos.jpg", "Rött te" },
                    { 4, "https://sakiproducts.com/cdn/shop/articles/20221107133813-white-tea-recipe-blog_800x800.jpg?v=1667828741", "Vitt te" },
                    { 5, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/D2E2521B-2690-44B5-8BD5-0BAD5C76EB37/Derivates/290E3C0B-2A82-4243-8C73-BAA412C4CF80.jpg", "Övrigt" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Caffeine", "CategoryId", "Effect", "Image", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Låg koffein", 1, "hjälper till att lugna, förbättra mental klarhet och stärka ditt immunförsvar", "https://blog.piquelife.com/wp-content/uploads/2020/08/Jasmine-Tea-Benefits-5-Research-Backed-Benefits-of-Jasmine-Tea.png", "Jasmine te", "Grönt, svart & vitt" },
                    { 2, "Medium koffein", 1, "minska risken för flera kroniska sjukdomar, förbättra uppmärksamhet, minne och reaktionstid", "https://media.post.rvohealth.io/wp-content/uploads/2020/08/matcha-green-tea-732x549-thumbnail.jpg", "Matcha", "Grönt" },
                    { 3, "Låg koffein", 1, "Hög koncentration av antioxidanter", "https://www.foodfolder.se/media/5807/img_8874.jpg", "Yogi te green tea matcha lemon", "Grönt" },
                    { 4, "Låg koffein", 1, "Renar blodet", "https://htgetrid.com/assets/uploads/2018/03/poleznye-svojstva-i-protivopokazanija-chaja-lunczin.jpg", "Longjing te", "Grönt" },
                    { 5, "Hög koffein", 2, "Ökad energi", "https://portfoliocoffee.ca/cdn/shop/articles/benefits-of-earl-grey-tea.jpg", "Earl grey", "Svart" },
                    { 6, "Hög koffein", 2, "Fördelar för hjärthälsa", "https://www.thespicehouse.com/cdn/shop/articles/Chai_Masala_Tea_1200x1200.jpg", "Chai te/Masala chai", "Svart (Indiskt)" },
                    { 7, "Hög koffein", 2, "Välgörande för huden", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRiG0ICI8xUy0Ju5ok6ZsZ49nnKnJ0LG8iSkg", "Litchi", "Svart" },
                    { 8, "Inget koffein", 3, "Innehåller antioxidanter", "https://www.thes-traditions.com/img/cms/bienfaits-rooibos.jpg", "Rooibos", "Rött" },
                    { 9, "Inget koffein", 3, "Lugnande", "https://media.delitea.se/product-images/XL/arvid-nordquist-skogsglanta-rooibos-17st-2.jpg", "Skogsglänta Rooibos", "Rött" },
                    { 10, "Inget koffein", 4, "Lugnande", "https://www.teacultures.com/cache/white-cassis-1_10085/white-cassis-1-800-600-1250-625.jpg", "White Cassis", "Vitt" },
                    { 11, "Inget koffein", 4, "Lugnande", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxmRhyN1GjGMoEycRZfpb9b4ahFBlH_H9Vrg", "Jasmin silver needle", "Vitt" },
                    { 12, "Mellan koffein", 5, "Förbättrar fettcellernas funktioner", "https://www.schwarzenbach.ch/wp-content/uploads/2023/06/Tee-Oolong-Formosa-Jade-Dung-Tin.jpg", "Formosa Jade Oolong te", "Oolong" },
                    { 13, "Inget koffein", 5, "Gynnar nattsömnen", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRF3DI1j9GDEJk69X6MyCrCmqXla1B7tlce6w", "Pukka night time", "Örtte" },
                    { 14, "Mellan koffein", 5, "Bra för magen", "https://teasenz.eu/cdn/shop/files/gingsheng.jpg?v=1692527694&width=416", "Ginseng Oolongte", "Oolong" },
                    { 15, "Inget koffein", 5, "Bra för en rosslig hals", "https://thumbs.dreamstime.com/b/kinesiskt-krysantemumte-p%C3%A5-gammalt-tr%C3%A4-57014906.jpg", "Krysantemumte", "Örtte" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
