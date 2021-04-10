﻿using FagElGamous.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FagElGamous.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Policy = "adminPolicy")]
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

        //Artifact action methods
        [HttpGet]
        public IActionResult Artifact(int BurialId)
        {
            TempData["BurialId"] = BurialId;
            Burial burial = context.Burial.Single(b => b.BurialId == BurialId);
            return View(new ArtifactViewModel { 
                Artifacts = context.Artifacts.Where(a => a.BurialId == BurialId),
                Burial = burial,
                Location = context.Location.Single(l => l.LocationId == burial.LocationId)
            });
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

        //Biological Sample action methods
        [HttpGet]
        public IActionResult BiologicalSample(int BurialId)
        {
            TempData["BurialId"] = BurialId;
            Burial burial = context.Burial.Single(b => b.BurialId == BurialId);
            return View(new BiologicalSampleViewModel
            {
                BiologicalSamples = context.BiologicalSample.Where(bs => bs.BurialId == BurialId),
                Burial = burial,
                Location = context.Location.Single(l => l.LocationId == burial.LocationId)
            });
        }
        [HttpGet]
        public IActionResult AddBioSample()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBioSample(BiologicalSample bs)
        {
            bs.BurialId = (int)TempData["BurialId"];
            context.BiologicalSample.Add(bs);
            //context.SaveChanges();
            return RedirectToAction("BiologicalSample", new { BurialId = bs.BurialId });
        }

        //C14 Sample Action Methods
        [HttpGet]
        public IActionResult C14Sample(int BurialId)
        {
            TempData["BurialId"] = BurialId;
            Burial burial = context.Burial.Single(b => b.BurialId == BurialId);
            return View(new C14SampleViewModel
            {
                C14Samples = context.C14Sample.Where(c => c.BurialId == BurialId),
                Burial = burial,
                Location = context.Location.Single(l => l.LocationId == burial.LocationId)
            });
        }
        [HttpGet]
        public IActionResult AddC14()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddC14(C14Sample c)
        {
            c.BurialId = (int)TempData["BurialId"];
            c.Calibrated95CalendarDateSpan = (int)Math.Abs((decimal)(c.Calibrated95CalendarDateMax) - (decimal)(c.Calibrated95CalendarDateMin));
            decimal decAvg;
            int Avg;
            decAvg = ((decimal)c.Calibrated95CalendarDateMax + (decimal)c.Calibrated95CalendarDateMin) / 2;
            //Avg = (int)Math.Ceiling(Math.Abs(((decimal)c.Calibrated95CalendarDateMax + (decimal)c.Calibrated95CalendarDateMin) / 2));
            if (decAvg < 0)
            {
                Avg = (int)Math.Abs(Math.Floor(decAvg));
                c.Calibrated95CalendarDateAvg = Avg + " BC";
            }
            else if (decAvg > 0)
            {
                Avg = (int)Math.Ceiling(decAvg);
                c.Calibrated95CalendarDateAvg = Avg + "";
            }
            else
            {
                c.Calibrated95CalendarDateAvg = "0";
            }
            context.C14Sample.Add(c);
            //context.SaveChanges();
            return RedirectToAction("C14Sample", new { BurialId = c.BurialId });
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
