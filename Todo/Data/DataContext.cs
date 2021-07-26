using Microsoft.EntityFrameworkCore;
using Todo.Entities;

namespace Todo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }
    }
}
