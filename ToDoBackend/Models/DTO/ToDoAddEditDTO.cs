using System.ComponentModel.DataAnnotations;

namespace ToDoBackend.Models.DTO
{
    public class ToDoAddEditDTO
    {
        public string? TaskName { get; set; }

        
        public Boolean? Completed { get; set; }
    }
}
