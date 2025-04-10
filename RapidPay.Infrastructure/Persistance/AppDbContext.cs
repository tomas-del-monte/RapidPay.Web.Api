using Microsoft.EntityFrameworkCore;
using RapidPay.Domain.Models;

namespace RapidPay.Web.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Card> Cards => Set<Card>();
        public DbSet<User> Users { get; set; }
    }
}
