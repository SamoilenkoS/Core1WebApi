using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreDAL
{
    public class EfCoreContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }
        public DbSet<GoodDto> Goods { get; set; }
        public DbSet<WarehouseDto> Warehouses { get; set; }

        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
