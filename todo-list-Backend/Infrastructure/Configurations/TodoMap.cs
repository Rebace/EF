using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using To_Do_List_Backend.Domain;

namespace todo_list_Backend.Infrastructure.Configurations
{
    public class TodoMap : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();

            builder.Property(x => x.IsDone).HasDefaultValue(false);
        }
    }
}
