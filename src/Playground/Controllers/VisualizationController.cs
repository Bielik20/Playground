using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playground.Data;
using Playground.Models.VisualizationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Controllers
{
    public class VisualizationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisualizationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BaseExample()
        {
            return View();
        }

        public IActionResult BackendExample()
        {
            var list = new List<KeyValuePair<string, int>>();
            list.Add(new KeyValuePair<string, int>("Mushrooms", 3));
            list.Add(new KeyValuePair<string, int>("Onios", 1));
            list.Add(new KeyValuePair<string, int>("Olives", 1));
            list.Add(new KeyValuePair<string, int>("Zucchini", 1));
            list.Add(new KeyValuePair<string, int>("Pepperoni", 2));

            return View(list);
        }

        public IActionResult JSPrint()
        {
            var list = new List<KeyValuePair<string, int>>();
            list.Add(new KeyValuePair<string, int>("Mushrooms", 3));
            list.Add(new KeyValuePair<string, int>("Onios", 1));
            list.Add(new KeyValuePair<string, int>("Olives", 1));
            list.Add(new KeyValuePair<string, int>("Zucchini", 1));
            list.Add(new KeyValuePair<string, int>("Pepperoni", 2));

            return View(list);
        }

        public async Task<IActionResult> BackendPrint()
        {
            var meals = from m in _context.Meal
                        select m;

            var model = new BackendPrintViewModel
            {
                List = await meals.ToListAsync(),
                ImageURI = ""
            };

            return View(model);
        }

        public async Task<IActionResult> PrintImage(string ImageURI)
        {
            if (ImageURI == "")
            {
                return NotFound();
            }

            return View();
        }
    }
}
