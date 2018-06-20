namespace UpdateQ.Data
{
    using Microsoft.EntityFrameworkCore;
    using UpdateQ.Data.Configuration;
    using UpdateQ.Model;

    public class UpdateQContext : DbContext
    {
        public UpdateQContext(DbContextOptions<UpdateQContext> options) : base(options)
        { }

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
        }
    }
}
