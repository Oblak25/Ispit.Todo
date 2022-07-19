using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Todo.Service
{
    public class TodolistService : ITodolistService
    {

        private readonly ApplicationDbContext db;

        public async Task<Todolist> Add(string kategorijaTodo, ApplicationUser applicationUser)
        {
            var dbo = new Todolist
            {

                KategorijaTodo = kategorijaTodo,
                ApplicationUser = applicationUser,
                TaskList = (ICollection<TaskList>)await db.TaskList.FirstOrDefaultAsync()



            };

            db.Todolist.Add(dbo);
            await db.SaveChangesAsync();
            return dbo;


        }

        public async Task<Todolist> Add(string kategorijaTodo, string applicationUserId)
        {
            var user = await db.ApplicationUser.FirstOrDefaultAsync(x => x.Id == applicationUserId);
            return await Add(kategorijaTodo, user);

        }

    }
}
