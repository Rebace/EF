using Microsoft.EntityFrameworkCore;
using todo_list_Backend.Infrastructure.Configurations;

namespace todo_list_Backend.Infrastructure
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoMap());
        }
    }
}
