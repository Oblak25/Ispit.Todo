using Ispit.Todo.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Ispit.Todo.Models
{
    public class TaskList: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Akcija { get; set; }
        public bool JeRjeseno { get; set; }
        public Todolist Todolist { get; set; }
        public DateTime Created { get; set; }
    }
}
