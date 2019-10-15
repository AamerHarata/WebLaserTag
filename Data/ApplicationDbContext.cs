using Microsoft.EntityFrameworkCore;
using WebLaserTag.Models;

namespace WebLaserTag.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerData> PlayersData { get; set; }
        public DbSet<PlayerInGame> PlayersInGame { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PlayerInGame>()
                .HasKey(s => new {s.PlayerId, s.GameId});
//            builder.Entity<PlayerData>()
//                .HasKey(s => new {s.PlayerId});
            


        }
    }
}