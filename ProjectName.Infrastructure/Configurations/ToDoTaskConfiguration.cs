using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Entities;
namespace ProjectName.Infrastructure.Configurations
{
    internal sealed class ToDoTaskConfiguration : IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Description).HasMaxLength(1000);
            builder.Property(t => t.DueDate).IsRequired();
            builder.Property(t => t.Priority).HasConversion<string>().IsRequired();
        }
    }
}
