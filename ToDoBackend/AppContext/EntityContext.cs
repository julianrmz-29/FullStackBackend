using Microsoft.EntityFrameworkCore;
using ToDoBackend.Models;

namespace ToDoBackend.AppContext
{
    public class EntityContext: DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options): base(options) {  }

        public DbSet<ToDoModel> ToDo { get; set; }
    }
}
