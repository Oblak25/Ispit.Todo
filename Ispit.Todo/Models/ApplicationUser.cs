using Ispit.Todo.Models.Interface;
using Microsoft.AspNetCore.Identity;

namespace Ispit.Todo.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Todolist> Todolist { get; set; }
    }
}
