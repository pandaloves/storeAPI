using Microsoft.EntityFrameworkCore;
using storeAPI.Models;

namespace storeAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Grönt te", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHfamFahLTBWDTLUKhzs6wYtrsZd5HHjmTtA&s" },
                new Category { Id = 2, Name = "Svart te", Image = "https://www.healthifyme.com/blog/wp-content/uploads/2020/02/Black-Tea-2-1.jpg" },
                new Category { Id = 3, Name = "Rött te", Image = "https://kahlstkh.se/wp-content/uploads/2018/03/te-rooibos.jpg" },
                new Category { Id = 4, Name = "Vitt te", Image = "https://sakiproducts.com/cdn/shop/articles/20221107133813-white-tea-recipe-blog_800x800.jpg?v=1667828741" },
                new Category { Id = 5, Name = "Övrigt", Image = "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/D2E2521B-2690-44B5-8BD5-0BAD5C76EB37/Derivates/290E3C0B-2A82-4243-8C73-BAA412C4CF80.jpg" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Jasmine te", Image = "https://blog.piquelife.com/wp-content/uploads/2020/08/Jasmine-Tea-Benefits-5-Research-Backed-Benefits-of-Jasmine-Tea.png", Effect = "hjälper till att lugna, förbättra mental klarhet och stärka ditt immunförsvar", Caffeine = "Låg koffein", Type = "Grönt, svart & vitt", CategoryId = 1 },
                new Product { Id = 2, Name = "Matcha", Image = "https://media.post.rvohealth.io/wp-content/uploads/2020/08/matcha-green-tea-732x549-thumbnail.jpg", Effect = "minska risken för flera kroniska sjukdomar, förbättra uppmärksamhet, minne och reaktionstid", Caffeine = "Medium koffein", Type = "Grönt", CategoryId = 1 },
                new Product { Id = 3, Name = "Yogi te green tea matcha lemon", Image = "https://www.foodfolder.se/media/5807/img_8874.jpg", Effect = "Hög koncentration av antioxidanter", Caffeine = "Låg koffein", Type = "Grönt", CategoryId = 1 },
                new Product { Id = 4, Name = "Longjing te", Image = "https://htgetrid.com/assets/uploads/2018/03/poleznye-svojstva-i-protivopokazanija-chaja-lunczin.jpg", Effect = "Renar blodet", Caffeine = "Låg koffein", Type = "Grönt", CategoryId = 1 },
                new Product { Id = 5, Name = "Earl grey", Image = "https://portfoliocoffee.ca/cdn/shop/articles/benefits-of-earl-grey-tea.jpg", Effect = "Ökad energi", Caffeine = "Hög koffein", Type = "Svart", CategoryId = 2 },
                new Product { Id = 6, Name = "Chai te/Masala chai", Image = "https://www.thespicehouse.com/cdn/shop/articles/Chai_Masala_Tea_1200x1200.jpg", Effect = "Fördelar för hjärthälsa", Caffeine = "Hög koffein", Type = "Svart (Indiskt)", CategoryId = 2 },
                new Product { Id = 7, Name = "Litchi", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRiG0ICI8xUy0Ju5ok6ZsZ49nnKnJ0LG8iSkg", Effect = "Välgörande för huden", Caffeine = "Hög koffein", Type = "Svart", CategoryId = 2 },
                new Product { Id = 8, Name = "Rooibos", Image = "https://www.thes-traditions.com/img/cms/bienfaits-rooibos.jpg", Effect = "Innehåller antioxidanter", Caffeine = "Inget koffein", Type = "Rött", CategoryId = 3 },
                new Product { Id = 9, Name = "Skogsglänta Rooibos", Image = "https://media.delitea.se/product-images/XL/arvid-nordquist-skogsglanta-rooibos-17st-2.jpg", Effect = "Lugnande", Caffeine = "Inget koffein", Type = "Rött", CategoryId = 3 },
                new Product { Id = 10, Name = "White Cassis", Image = "https://www.teacultures.com/cache/white-cassis-1_10085/white-cassis-1-800-600-1250-625.jpg", Effect = "Lugnande", Caffeine = "Inget koffein", Type = "Vitt", CategoryId = 4 },
                new Product { Id = 11, Name = "Jasmin silver needle", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxmRhyN1GjGMoEycRZfpb9b4ahFBlH_H9Vrg", Effect = "Lugnande", Caffeine = "Inget koffein", Type = "Vitt", CategoryId = 4 },
                new Product { Id = 12, Name = "Formosa Jade Oolong te", Image = "https://www.schwarzenbach.ch/wp-content/uploads/2023/06/Tee-Oolong-Formosa-Jade-Dung-Tin.jpg", Effect = "Förbättrar fettcellernas funktioner", Caffeine = "Mellan koffein", Type = "Oolong", CategoryId = 5 },
                new Product { Id = 13, Name = "Pukka night time", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRF3DI1j9GDEJk69X6MyCrCmqXla1B7tlce6w", Effect = "Gynnar nattsömnen", Caffeine = "Inget koffein", Type = "Örtte", CategoryId = 5 },
                new Product { Id = 14, Name = "Ginseng Oolongte", Image = "https://teasenz.eu/cdn/shop/files/gingsheng.jpg?v=1692527694&width=416", Effect = "Bra för magen", Caffeine = "Mellan koffein", Type = "Oolong", CategoryId = 5 },
                new Product { Id = 15, Name = "Krysantemumte", Image = "https://thumbs.dreamstime.com/b/kinesiskt-krysantemumte-p%C3%A5-gammalt-tr%C3%A4-57014906.jpg", Effect = "Bra för en rosslig hals", Caffeine = "Inget koffein", Type = "Örtte", CategoryId = 5 }
            );
        }
    }
}