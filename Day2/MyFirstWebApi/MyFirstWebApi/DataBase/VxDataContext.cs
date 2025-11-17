using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApi.DataBase;

public class VxDataContext : DbContext
{
    public VxDataContext(DbContextOptions<VxDataContext> options) : base(options)
    {

    }
    public DbSet<CategoryEntity> Categories { get; set; }

    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductEntity>().HasIndex(x => x.Price);

        modelBuilder.Entity<CategoryEntity>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);


    }
}
