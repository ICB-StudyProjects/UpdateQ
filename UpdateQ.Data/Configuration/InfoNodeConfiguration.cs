namespace UpdateQ.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using UpdateQ.Model;

    public class InfoNodeConfiguration : IEntityTypeConfiguration<InfoNode>
    {
        public void Configure(EntityTypeBuilder<InfoNode> builder)
        {
            builder.ToTable("InfoNodes");

            builder.Property(i => i.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(i => i.ParentInfoNode)
                .WithMany(i => i.ChildInfoNodes)
                .HasForeignKey(i => i.ParentInfoNodeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
