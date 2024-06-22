using Microsoft.EntityFrameworkCore;
using ShopMetta.Models;


namespace ShopMetta
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<CreateOrder> Order_for_creation { get; set; }

        public DbSet<OverallStatistic> OverallStatistics { get; set; }
        public DbSet<ProductStatistic> ProductStatistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("host=localhost; uid = root; pwd = root; database = metta");
        }
    }
}
