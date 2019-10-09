using Microsoft.EntityFrameworkCore;
using WebLaserTag.Models;

namespace WebLaserTag.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<PlayerData> PlayersData { get; set; }
    }
}