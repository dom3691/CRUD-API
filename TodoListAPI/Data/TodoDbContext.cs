using Microsoft.EntityFrameworkCore;
using TodoListAPI.Model;

namespace TodoListAPI.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TodoModel> Todo_tbl { get; set; }
    }
}
