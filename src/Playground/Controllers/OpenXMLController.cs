using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Playground.Services;
using Playground.Data;

namespace Playground.Controllers
{
    public class OpenXMLController : Controller
    {
        private IHostingEnvironment _environment;
        private PowerPointCreator _creator;

        public OpenXMLController(IHostingEnvironment environment, ApplicationDbContext context, PowerPointCreator creator)
        {
            _environment = environment;
            _creator = creator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public FileResult DownloadFile()
        {
            MemoryStream ms = new MemoryStream();
            TextWriter tw = new StreamWriter(ms);
            tw.WriteLine("Line 1");
            tw.WriteLine("Line 2");
            tw.WriteLine("Line 3");
            tw.Flush();
            byte[] bytes = ms.ToArray();
            ms.Close();

            return File(bytes, "application/force-download", "test.txt");
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return View("Index");
        }

        public async Task<FileResult> CreatePP()
        {
            return File(await _creator.CreatePackage(), "application/force-download", "myPresentation.pptx");
        }
    }
}