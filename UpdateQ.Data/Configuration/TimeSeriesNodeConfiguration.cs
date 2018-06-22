namespace UpdateQ.Data.Configuration
{
    using UpdateQ.Model.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TimeSeriesNodeConfiguration : IEntityTypeConfiguration<TimeSeriesNode>
    {
        public void Configure(EntityTypeBuilder<TimeSeriesNode> builder)
        {
            builder.ToTable("TimeSeriesNodes");

            builder
                .HasOne(t => t.InfoNode)
                .WithMany(i => i.TimeSeriesNodes)
                .HasForeignKey(t =>t.InfoNodeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
