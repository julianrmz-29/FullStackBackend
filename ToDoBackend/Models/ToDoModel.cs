using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoBackend.Models
{
    public class ToDoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? TaskName { get; set; }

        public Boolean? Completed { get; set; }
              
        
        public DateTime CreationDate { get; set; }
                
        
        public DateTime? UpdateDate { get; set; }

    }
}
