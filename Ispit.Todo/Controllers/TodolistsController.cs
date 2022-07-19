using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Ispit.Todo.Service;

namespace Ispit.Todo.Controllers
{
    [Authorize]

    public class TodolistsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public TodolistsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }



        // GET: Todolists
        public async Task<IActionResult> Index()
        {
              return _context.Todolist != null ? 
                          View(await _context.Todolist.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Todolist'  is null.");
        }

        // GET: Todolists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Todolist == null)
            {
                return NotFound();
            }

            var todolist = await _context.Todolist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todolist == null)
            {
                return NotFound();
            }

            return View(todolist);
        }

        // GET: Todolists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todolists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategorijaTodo,Created")] Todolist todolist)
        {
            //if (ModelState.IsValid)
            //{
            //}
            var user = await userManager.GetUserAsync(User);
            todolist.ApplicationUser = user;
                _context.Add(todolist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
         



        }

        // GET: Todolists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Todolist == null)
            {
                return NotFound();
            }

            var todolist = await _context.Todolist.FindAsync(id);
            if (todolist == null)
            {
                return NotFound();
            }
            return View(todolist);
        }

        // POST: Todolists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategorijaTodo,Created")] Todolist todolist)
        {
            if (id != todolist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todolist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodolistExists(todolist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todolist);
        }

        // GET: Todolists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Todolist == null)
            {
                return NotFound();
            }

            var todolist = await _context.Todolist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todolist == null)
            {
                return NotFound();
            }

            return View(todolist);
        }

        // POST: Todolists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Todolist == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Todolist'  is null.");
            }
            var todolist = await _context.Todolist.FindAsync(id);
            if (todolist != null)
            {
                _context.Todolist.Remove(todolist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodolistExists(int id)
        {
          return (_context.Todolist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
