using ToDoBackend.Models;
using ToDoBackend.Models.DTO;

namespace ToDoBackend.AppServices
{
    public interface ITodoAppService
    {
        Task<ServiceResponse<List<ToDoModel>>> GetAllTodoAsync();
        Task<ServiceResponse<ToDoModel>> AddTodoAsync(ToDoAddEditDTO toDoModel);

        Task<ServiceResponse<ToDoModel>> UpdateTodoAsync(int id, ToDoAddEditDTO toDoModel);

        Task<ServiceResponse<ToDoModel>> DeleteTodoAsync(int id);
    }
}
