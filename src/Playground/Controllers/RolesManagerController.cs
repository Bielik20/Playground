using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Playground.Data;
using Microsoft.EntityFrameworkCore;

namespace Playground.Controllers
{
    public class RolesManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var roles = from m in _context.Roles
                        select m;

            return View(await roles.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                _context.Roles.Add(new IdentityRole { Name = role.Name });
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            var role = await _context.Roles.SingleOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(m => m.Id == id);
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}