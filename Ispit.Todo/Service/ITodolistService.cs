using Ispit.Todo.Models;

namespace Ispit.Todo.Service
{
    public interface ITodolistService
    {
        Task<Todolist> Add(string kategorijaTodo, ApplicationUser applicationUser);
        Task<Todolist> Add(string kategorijaTodo, string applicationUserId);
    }
}