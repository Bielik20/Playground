using Microsoft.AspNetCore.Mvc;
using Playground.Models.VisualizationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Controllers
{
    public class VisualizationController : Controller
    {
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

        public IActionResult BackendPrint()
        {
            var list = new List<KeyValuePair<string, int>>();
            list.Add(new KeyValuePair<string, int>("Mushrooms", 3));
            list.Add(new KeyValuePair<string, int>("Onios", 1));
            list.Add(new KeyValuePair<string, int>("Olives", 1));
            list.Add(new KeyValuePair<string, int>("Zucchini", 1));
            list.Add(new KeyValuePair<string, int>("Pepperoni", 2));

            var model = new BackendPrintViewModel
            {
                List = list,
                ImageURI = ""
            };

            return View(model);
        }

        public async Task<IActionResult> Edit(string ImageURI)
        {
            if (ImageURI == "")
            {
                return NotFound();
            }

            return View();
        }
    }
}
