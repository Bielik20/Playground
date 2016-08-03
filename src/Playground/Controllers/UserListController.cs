using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Playground.Data;
using Playground.Models;
using Playground.Models.UserListViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Controllers
{
    public class UserListController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public UserListController(
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var users = from m in _context.Users
                        select m;


            return View(await users.ToListAsync());
        }


        public async Task<IActionResult> Details(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = userViewModel.Name, Email = userViewModel.Email, };
                var result = await _userManager.CreateAsync(user, userViewModel.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation(3, "Admin created a new account with password.");

                    //Adds roles to user
                    await AddRole(userViewModel.Name, userViewModel.Roles);
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            return View(userViewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    System.Console.WriteLine("\n\n\n____1\n" + user.UserName + "\n\n\n");

                    var result = await _userManager.UpdateAsync(user);
                    await _context.SaveChangesAsync();
                    System.Console.WriteLine("\n\n\n____2\n\n\n");
                    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private async Task<bool> AddRole(string userName, List<string> rolesNames)
        {
            try
            {
                var currentUser = await _userManager.FindByNameAsync(userName);
                foreach (var role in rolesNames)
                {
                    System.Console.WriteLine("After finding user\n\n\n\n");
                    System.Console.WriteLine("Role: -" + role + "-\n\n\n\n");
                    await _userManager.AddToRoleAsync(currentUser, role);
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    }
}
