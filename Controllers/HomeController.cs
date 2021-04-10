using FagElGamous.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FagElGamous.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FagElGamous.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FagElGamousContext context;

        public HomeController(ILogger<HomeController> logger, FagElGamousContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View(context.Location);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Burial()
        {
            IQueryable<Burial> query = context.Burial.Include(b => b.Location);

            return View(query);
        }

        [HttpGet]
        public IActionResult AddBurial()
        {
            return View(new BurialViewModel
            {
                Location = context.Location
            });
        }
        [HttpPost]
        public IActionResult AddBurial(BurialViewModel b, int LocationId, DateTime date)
        {
            b.Burial.LocationId = LocationId;
            b.Burial.DayFound = date.ToString("dd");
            b.Burial.MonthFound = date.ToString("MM");
            b.Burial.YearFound = date.ToString("yyyy");
            context.Burial.Add(b.Burial);
            //context.SaveChanges();
            return RedirectToAction("AddBurial");
        }

        [HttpGet]
        public IActionResult AddLocation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLocation(Location l)
        {
            l.LocationString = l.BurialLocationNs + " " + l.LowPairNs + "/" + l.HighPairNs + " " + l.BurialLocationEw + " " + l.LowPairEw + "/" + l.HighPairEw + " " + l.BurialSubplot;
            foreach(Location loc in context.Location)
            {
                if (l.LocationString == loc.LocationString)
                {
                    //Return Error Page for Location Already stored
                    return View();
                }
            }
            context.Location.Add(l);
            //context.SaveChanges();
            //Return Success page.
            return View();
        }
        [HttpGet]
        public IActionResult Artifact(int BurialId)
        {
            TempData["BurialId"] = BurialId;
            return View(context.Artifacts.Where(a => a.BurialId == BurialId));
        }
        [HttpGet]
        public IActionResult AddArtifact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddArtifact(Artifacts a)
        {
            a.BurialId = (int)TempData["BurialId"];
            context.Artifacts.Add(a);
            context.SaveChanges();
            return RedirectToAction("Artifact", new { BurialId = a.BurialId });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
