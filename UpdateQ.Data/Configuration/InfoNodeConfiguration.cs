namespace UpdateQ.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using UpdateQ.Model.Entities;

    public class InfoNodeConfiguration : IEntityTypeConfiguration<InfoNode>
    {
        public void Configure(EntityTypeBuilder<InfoNode> builder)
        {
            builder.ToTable("InfoNodes");

            builder
                .HasOne(i => i.ParentInfoNode)
                .WithMany(i => i.ChildInfoNodes)
                .HasForeignKey(i => i.ParentInfoNodeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(i => i.TimeSeriesNodes)
                .WithOne(t => t.InfoNode)
                .HasForeignKey(t => t.InfoNodeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
