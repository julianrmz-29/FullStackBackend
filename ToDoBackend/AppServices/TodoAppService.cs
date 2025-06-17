using AutoMapper;
using ToDoBackend.Models;
using ToDoBackend.Models.DTO;
using ToDoBackend.Repository;

namespace ToDoBackend.AppServices
{
    public class TodoAppService: ITodoAppService
    {
        private readonly ToDoRepository _repository;
        private readonly IMapper _mapper;

        public TodoAppService(ToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ToDoModel>> AddTodoAsync(ToDoAddEditDTO toDoModel)
        {
            try
            {
                if (toDoModel is null || string.IsNullOrEmpty(toDoModel.TaskName)) 
                {
                    return new ServiceResponse<ToDoModel>
                    {
                        Success = false,
                        Message = "The field name is required."
                    };
                } 
                var todoMap = _mapper.Map<ToDoModel>(toDoModel);
                var entity = await _repository.AddTodo(todoMap);

                return new ServiceResponse<ToDoModel>
                {
                    Success = true,
                    Message = "ToDo added successfully.",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ToDoModel>
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        public async Task<ServiceResponse<ToDoModel>> DeleteTodoAsync(int id)
        {
            try
            {
                
                var entity = await _repository.DeleteTodo(id);
                if (entity is null)
                {
                    return new ServiceResponse<ToDoModel>
                    {
                        Success = false,
                        Message = "ToDo id invalid"
                    };
                }
                return new ServiceResponse<ToDoModel>
                {
                    Success = true,
                    Message = "ToDo remove successfully.",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ToDoModel>
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<ToDoModel>>> GetAllTodoAsync()
        {
            try
            {
                var todoList = await _repository.GetAllToDoList();
                if (todoList?.Count == 0)
                {
                    return new ServiceResponse<List<ToDoModel>>
                    {
                        Success = true,
                        Message = "No data",
                        Data = todoList
                    };
                }
                return new ServiceResponse<List<ToDoModel>>
                {
                    Success = true,
                    Message = "Todos retrieved successfully.",
                    Data = todoList
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<ToDoModel>>
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        public async Task<ServiceResponse<ToDoModel>> UpdateTodoAsync(int id, ToDoAddEditDTO toDoModel)
        {
            try
            {
                if (id < 0)
                {
                    return new ServiceResponse<ToDoModel>
                    {
                        Success = false,
                        Message = "ToDo id invalid"
                    };
                }
                if (string.IsNullOrEmpty(toDoModel.TaskName))
                {
                    return new ServiceResponse<ToDoModel>
                    {
                        Success = false,
                        Message = "the field name is required"
                    };
                }
                var todoMap = _mapper.Map<ToDoModel>(toDoModel);
                todoMap.Id = id;
                var entity = _repository.UpdateTodo(todoMap);

                if (entity is null)
                {
                    return new ServiceResponse<ToDoModel>
                    {
                        Success = false,
                        Message = "Not found"
                    };
                }
                return new ServiceResponse<ToDoModel>
                {
                    Success = true,
                    Message = "ToDo update successfully.",
                    Data = todoMap
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ToDoModel>
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }
    }
}
