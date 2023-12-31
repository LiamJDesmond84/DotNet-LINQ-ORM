using Microsoft.EntityFrameworkCore;


namespace SportsORM.Models
{
    /// <summary>Context class representing a session with our sqlite
    /// database allowing us to query or save data</summary>
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite("Data Source=SportsORM.db");


        // DBSet<Leagues/Teams/Players> directly connected to the DataController's static tables AND/OR Models(not sure which comes first, but tested while renaming one of the tables) - Not sure about PlayerTeam
        public DbSet<League> Leagues {get;set;}
        public DbSet<Team> Teams {get;set;}
        public DbSet<Player> Players {get;set;}
        public DbSet<PlayerTeam> PlayerTeams {get;set;}

    }
}
