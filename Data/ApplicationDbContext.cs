using Microsoft.EntityFrameworkCore;
using WebLaserTag.Models;

namespace WebLaserTag.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerData> PlayersData { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
//            builder.Entity<PlayerData>()
//                .HasKey(s => new {s.Player.MacAddress});
            


        }
    }
}