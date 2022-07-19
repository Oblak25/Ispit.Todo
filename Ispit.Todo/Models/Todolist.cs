using Ispit.Todo.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Ispit.Todo.Models
{
    public class Todolist: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string KategorijaTodo { get; set; }

        public ICollection<TaskList> TaskList { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public DateTime Created { get; set; }
    }
}
