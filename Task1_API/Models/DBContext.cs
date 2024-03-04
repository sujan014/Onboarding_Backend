using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Task1_API.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Product> Products { get; set; }    
        public virtual DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity => {
                entity.Property(column => column.Id)
                .HasColumnName("CustomerId");
            });
            modelBuilder.Entity<Store>(entity => {
                entity.Property(column => column.Id)
                .HasColumnName("StoreId");
            });
            modelBuilder.Entity<Product>(entity => {
                entity.Property(column => column.Id)
                .HasColumnName("ProductId");
            });
        }
        partial void OnModelCreatingpartial(ModelBuilder modelBuilder);
    }
}
