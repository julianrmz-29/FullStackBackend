using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ToDoBackend.AppContext;
using ToDoBackend.Models;

namespace ToDoBackend.Repository
{
    public class ToDoRepository
    {
        private readonly EntityContext _datacontext;

        public ToDoRepository(EntityContext datacontext)
        {
           _datacontext = datacontext;
        }

        public async Task<List<ToDoModel>> GetAllToDoList()
        {
            return await _datacontext.ToDo.ToListAsync();
        }

        public async Task<ToDoModel> AddTodo(ToDoModel toDo)
        {
            string formattedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            toDo.CreationDate = DateTime.Parse(formattedDate);
            await _datacontext.ToDo.AddAsync(toDo);
            await _datacontext.SaveChangesAsync();
            return toDo;
        }

        public async Task<ToDoModel> UpdateTodo(ToDoModel toDo)
        {
            var entity = await _datacontext.ToDo.FindAsync(toDo.Id);
            if (entity is null) return null;

            string formattedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            entity.TaskName = toDo.TaskName;
            entity.Completed = toDo.Completed;
            entity.UpdateDate = DateTime.Parse(formattedDate);

            await _datacontext.SaveChangesAsync();

            return toDo;

        }

        public async Task<ToDoModel?> DeleteTodo(int id)
        {
            var entity = await _datacontext.ToDo.FindAsync(id);
            if (entity is null) return null;
            _datacontext.ToDo.Remove(entity);
            await _datacontext.SaveChangesAsync();
            return entity;
        }
    }
}
