namespace UpdateQ.Data
{
    using Microsoft.EntityFrameworkCore;
    using UpdateQ.Data.Configuration;
    using UpdateQ.Data.Seed;
    using UpdateQ.Model.Entities;

    public class UpdateQContext : DbContext
    {
        // May have problem w/ DesignTimeDbContext
        public UpdateQContext() {}

        public UpdateQContext(DbContextOptions<UpdateQContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<InfoNode> InfoNodes { get; set; }
        public DbSet<TimeSeriesNode> TimeSeriesNodes { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new InfoNodeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSeriesNodeConfiguration());

            // TODO: Implement database seed
            //modelBuilder.SeedDb();
        }
    }
}
