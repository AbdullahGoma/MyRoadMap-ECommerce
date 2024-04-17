using Bulky.DataAccess.Persistence.Seeds;

namespace Bulky.DataAccess.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Apply Configurations from all IEntityTypeConfiguration<T>
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seed Categories Data 
            builder.Entity<Category>().HasData(CategoriesData.Data());

            // Seed Products Data 
            builder.Entity<Product>().HasData(ProductsData.Data()); 

            var cascadeFKs = builder.Model.GetEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
