using Microsoft.EntityFrameworkCore;

namespace NflTeamAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<NflTeam> NflTeams => Set<NflTeam>();
    }
}
