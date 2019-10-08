using Microsoft.EntityFrameworkCore;

namespace WebLaserTag.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context, bool isDevelopment)
        {
            if (!isDevelopment)
            {
                context.Database.Migrate();
                return;
            }
            
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
    }
}