using Microsoft.EntityFrameworkCore;

namespace AskToniApi.Models
{
    public class AskToniContext : DbContext
    {
        public AskToniContext(DbContextOptions<AskToniContext> options)
            : base(options)
        {
        }

        public DbSet<Recommendation> Recommendations { get; set; }

    }
}