namespace UpdateQ.Data
{
    using Microsoft.EntityFrameworkCore;
    using UpdateQ.Model;

    public class UpdateQContext : DbContext
    {
        public UpdateQContext(DbContextOptions<UpdateQContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<InfoNode> InfoNodes { get; set; }
        public DbSet<TimeSeriesNode> TimeSeriesNodes { get; set; }
    }
}
