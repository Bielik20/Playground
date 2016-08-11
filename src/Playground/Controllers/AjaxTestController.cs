using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Playground.Data;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Playground.Controllers
{
    public class AjaxTestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AjaxTestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string GetText()
        {
            return "This text is generated in controller.";
        }

        public string GetTextWithNumber(int number)
        {
            return "Number you chose is " + number.ToString();
        }

        public string GetHint(string text)
        {
            var meal = from m in _context.Meal
                       where m.Name.StartsWith(text)
                       select m;

            if (meal.Any())
                return meal.FirstOrDefault().Name;
            else
                return "No meal found.";
        }

        public async Task<string> GetHintList(string text)
        {
            var meal = from m in _context.Meal
                       where m.Name.StartsWith(text)
                       select m;

            var builder = new System.Text.StringBuilder();
            if (meal.Any())
            {
                foreach (var item in await meal.ToListAsync())
                {
                    builder.Append(String.Format("<option value='{0}'>", item.Name));
                }
                return builder.ToString();
            }

            return "";
        }

        public IActionResult AjaxPage()
        {
            return PartialView();
        }

        public IActionResult AjaxHomePage()
        {
            return PartialView("../Home/Index");
        }
    }
}