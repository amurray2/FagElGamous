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

        [Route("Home/Filter")]
        [HttpGet]
        public IActionResult Filter(int LocationId, string Age, string HeadDirection, int pageNum = 1)
        {
            //if (Age == "All")
            //{
            //    Age = null;
            //}
            //if (HeadDirection == "All")
            //{
            //    Age = null;
            //}
            //ViewBag.LocationId = LocationId;
            int pageSize = 1;
            IQueryable<Burial> burials;
            if (LocationId != 0 && Age == "All" && HeadDirection == "All")
            {
                burials = context.Burial.Where(b => b.LocationId == LocationId);
            }
            else if (LocationId != 0 && Age != "All" && HeadDirection == "All")
            {
                burials = context.Burial.Where(b => b.LocationId == LocationId && b.AgeCodeSingle == Age);
            }
            else if (LocationId != 0 && Age == "All" && HeadDirection != "All")
            {
                burials = context.Burial.Where(b => b.LocationId == LocationId && b.HeadDirection == HeadDirection);
            }
            else if (LocationId == 0 && Age != "All" && HeadDirection != "All")
            {
                burials = context.Burial.Where(b => b.AgeCodeSingle == Age && b.HeadDirection == HeadDirection);
            }
            else if (LocationId == 0 && Age != "All" && HeadDirection == "All")
            {
                burials = context.Burial.Where(b => b.AgeCodeSingle == Age);
            }
            else if (LocationId == 0 && Age == "All" && HeadDirection != "All")
            {
                burials = context.Burial.Where(b => b.HeadDirection == HeadDirection);
            }
            else if (LocationId != 0 && Age != "All" && HeadDirection != "All")
            {
                burials = context.Burial.Where(b => b.LocationId == LocationId && b.AgeCodeSingle == Age && b.HeadDirection == HeadDirection);
            }
            else
            {
                burials = context.Burial;
                //return RedirectToAction("Burial");
            }
            //burials = context.Burial.Where(b => b.LocationId == LocationId);


            return View(new SummaryPageViewModel
            {
                Burials = (burials
                    .Include(b => b.Location)
                    .OrderBy(b => b.Location.LocationString)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = burials.Count()
                },
                Locations = context.Location,
                LocationId = LocationId,
                Age = Age,
                HeadDirection = HeadDirection
            });
        }

        [HttpGet]
        public IActionResult Burial(int pageNum = 1)
        {
            int pageSize = 1;
            //IQueryable<Burial> query = context.Burial.Include(b => b.Location);

            return View(new SummaryPageViewModel
            {
                Burials = (context.Burial
                    .Include(b => b.Location)
                    .OrderBy(b => b.Location.LocationString)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = context.Burial.Count()
                },
                Locations = context.Location
            });
        }

        [HttpGet]
        public IActionResult SingleBurial(int BurialId)
        {
            Burial b = context.Burial.Include(b => b.Location).Single(b => b.BurialId == BurialId);
            return View(b);
        }

        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult AddBurial()
        {
            return View(new BurialViewModel
            {
                Location = context.Location
            });
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult AddBurial(BurialViewModel b, int LocationId, DateTime date)
        {
            b.Burial.LocationId = LocationId;
            b.Burial.DayFound = date.ToString("dd");
            b.Burial.MonthFound = date.ToString("MM");
            b.Burial.YearFound = date.ToString("yyyy");
            context.Burial.Add(b.Burial);

            //Location l = context.Location.Single(l => l.LocationId == LocationId);
            foreach (Burial burial in context.Burial.Where(b => b.LocationId == LocationId))
            {
                if (burial.BurialNumber == b.Burial.BurialNumber)
                {
                    //return Burial already stored.
                    return View("ErrorBurial");
                }
            }
            context.SaveChanges();
            return View("SuccessBurial");
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult EditBurial(int BurialID)
        {
            return View(new BurialViewModel
            {
                Location = context.Location,
                Burial = context.Burial.Single(b => b.BurialId == BurialID)
            });

        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult EditBurial(BurialViewModel b, int LocationId, DateTime date, int BurialId)
        {
            Burial newB = context.Burial.Single(bur => bur.BurialId == BurialId);
            newB.LocationId = LocationId;
            newB.BurialNumber = b.Burial.BurialNumber;
            newB.SouthToHead = b.Burial.SouthToHead;
            newB.SouthToFeet = b.Burial.SouthToFeet;
            newB.WestToHead = b.Burial.WestToHead;
            newB.WestToFeet = b.Burial.WestToFeet;
            newB.LengthOfRemains = b.Burial.LengthOfRemains;
            newB.BurialDepth = b.Burial.BurialDepth;
            newB.ArtifactFound = b.Burial.ArtifactFound;
            newB.TextileTaken = b.Burial.TextileTaken;
            newB.HairColor = b.Burial.HairColor;
            newB.AgeCodeSingle = b.Burial.AgeCodeSingle;
            newB.HeadDirection = b.Burial.HeadDirection;
            newB.InitialsOfDataEntryExpert = b.Burial.InitialsOfDataEntryExpert;
            if(date.ToString("yyyy") != "0001")
            {
                newB.DayFound = date.ToString("dd");
                newB.MonthFound = date.ToString("MM");
                newB.YearFound = date.ToString("yyyy");
            }
            context.SaveChanges();
            //Might be good to do a changes made success page.
            return RedirectToAction("Burial");
        }
        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public IActionResult DeleteBurial(int BurialId)
        {
            foreach (Artifacts a in context.Artifacts.Where(a => a.BurialId == BurialId))
            {
                context.Artifacts.Remove(a);
            }
            context.SaveChanges();
            foreach (C14Sample c in context.C14Sample.Where(c => c.BurialId == BurialId))
            {
                context.C14Sample.Remove(c);
            }
            context.SaveChanges();
            foreach (BiologicalSample bs in context.BiologicalSample.Where(bs => bs.BurialId == BurialId))
            {
                context.BiologicalSample.Remove(bs);
            }
            context.SaveChanges();
            foreach (Preservation p in context.Preservation.Where(p => p.BurialId == BurialId))
            {
                context.Preservation.Remove(p);
            }
            context.SaveChanges();
            foreach (Bones b in context.Bones.Where(b => b.BurialId == BurialId))
            {
                context.Remove(b);
            }
            context.SaveChanges();

            Burial burial = context.Burial.Single(b => b.BurialId == BurialId);
            context.Remove(burial);
            context.SaveChanges();
            return RedirectToAction("Burial");
        }

        //Location action methods
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult Locations()
        {
            return View(context.Location);
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult AddLocation()
        {
            return View();
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult AddLocation(Location l)
        {
            l.LocationString = l.BurialLocationNs + " " + l.LowPairNs + "/" + l.HighPairNs + " " + l.BurialLocationEw + " " + l.LowPairEw + "/" + l.HighPairEw + " " + l.BurialSubplot;
            foreach (Location loc in context.Location)
            {
                if (l.LocationString == loc.LocationString)
                {
                    //Return Error Page for Location Already stored
                    return View("ErrorLocation");
                }
            }
            context.Location.Add(l);
            context.SaveChanges();
            //Return Success page.
            return View("SuccessLocation");
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult EditLocation(int LocationId)
        {
            return View(context.Location.Single(l => l.LocationId == LocationId));
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult EditLocation(Location l)
        {
            Location newL = context.Location.Single(loc => loc.LocationId == l.LocationId);
            newL.BurialLocationNs = l.BurialLocationNs;
            newL.HighPairNs = l.HighPairNs;
            newL.LowPairNs = l.LowPairNs;
            newL.BurialLocationEw = l.BurialLocationEw;
            newL.HighPairEw = l.HighPairEw;
            newL.LowPairEw = l.LowPairEw;
            newL.BurialSubplot = l.BurialSubplot;
            l.LocationString = l.BurialLocationNs + " " + l.LowPairNs + "/" + l.HighPairNs + " " + l.BurialLocationEw + " " + l.LowPairEw + "/" + l.HighPairEw + " " + l.BurialSubplot;
            foreach (Location loc in context.Location)
            {
                if (l.LocationString == loc.LocationString)
                {
                    //Return Error Page for Location Already stored
                    return View("ErrorLocation");
                }
            }
            newL.LocationString = l.LocationString;
            context.SaveChanges();
            return View("SuccessLocation");
        }
        //Still wondering if we should allow users to do this.
        //[HttpPost]
        //public IActionResult DeleteLocation(int LocationId)
        //{

        //}

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
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult AddArtifact()
        {
            return View();
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult AddArtifact(Artifacts a)
        {
            a.BurialId = (int)TempData["BurialId"];
            context.Artifacts.Add(a);
            context.SaveChanges();
            return RedirectToAction("Artifact", new { BurialId = a.BurialId });
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult EditArtifact(int artifactId)
        {
            return View(context.Artifacts.Single(a => a.ArtifactId == artifactId));
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult EditArtifact(Artifacts a)
        {
            Artifacts newA = context.Artifacts.Single(art => art.ArtifactId == a.ArtifactId);
            newA.ArtifactDescription = a.ArtifactDescription;
            context.SaveChanges();
            return RedirectToAction("Artifact", new { BurialId = a.BurialId });
        }
        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public IActionResult DeleteArtifact(int ArtifactId)
        {
            Artifacts a = context.Artifacts.Single(art => art.ArtifactId == ArtifactId);
            context.Artifacts.Remove(a);
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
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult AddBioSample()
        {
            return View();
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult AddBioSample(BiologicalSample bs)
        {
            bs.BurialId = (int)TempData["BurialId"];
            context.BiologicalSample.Add(bs);
            context.SaveChanges();
            return RedirectToAction("BiologicalSample", new { BurialId = bs.BurialId });
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult EditBioSample(int BioId)
        {
            return View(context.BiologicalSample.Single(bs => bs.BioSampleId == BioId));
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult EditBioSample(BiologicalSample bs)
        {
            BiologicalSample newB = context.BiologicalSample.Single(b => b.BioSampleId == bs.BioSampleId);
            newB.RackNum = bs.RackNum;
            newB.BagNum = bs.BagNum;
            newB.PreviouslySampled = bs.PreviouslySampled;
            newB.Notes = bs.Notes;
            newB.Initials = bs.Initials;
            context.SaveChanges();
            return RedirectToAction("BiologicalSample", new { BurialId = bs.BurialId });
        }
        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public IActionResult DeleteBioSample(int BioId)
        {
            BiologicalSample bs = context.BiologicalSample.Single(bio => bio.BioSampleId == BioId);
            context.BiologicalSample.Remove(bs);
            context.SaveChanges();
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
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult AddC14()
        {
            return View();
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult AddC14(C14Sample c)
        {
            c.BurialId = (int)TempData["BurialId"];
            c.Calibrated95CalendarDateSpan = (int)Math.Abs((decimal)(c.Calibrated95CalendarDateMax) - (decimal)(c.Calibrated95CalendarDateMin));
            decimal decAvg;
            int Avg;
            decAvg = ((decimal)c.Calibrated95CalendarDateMax + (decimal)c.Calibrated95CalendarDateMin) / 2;
            Avg = (int)Math.Ceiling(Math.Abs(((decimal)c.Calibrated95CalendarDateMax + (decimal)c.Calibrated95CalendarDateMin) / 2));
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
            context.SaveChanges();
            return RedirectToAction("C14Sample", new { BurialId = c.BurialId });
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpGet]
        public IActionResult EditC14Sample(int C14Id)
        {
            C14Sample c = context.C14Sample.Single(c => c.C14SampleId == C14Id);
            return View(c);
        }
        [Authorize(Policy = "researcherPolicy")]
        [HttpPost]
        public IActionResult EditC14Sample(C14Sample c)
        {
            C14Sample newC = context.C14Sample.Single(c14 => c14.C14SampleId == c.C14SampleId);
            newC.RackNum = c.RackNum;
            newC.TubeNum = c.TubeNum;
            newC.Description = c.Description;
            newC.Location = c.Location;
            newC.Questions = c.Questions;
            newC.Conventia14cAgeBp = c.Conventia14cAgeBp;
            newC._14cCalendarDate = c._14cCalendarDate;
            newC.Calibrated95CalendarDateMax = c.Calibrated95CalendarDateMax;
            newC.Calibrated95CalendarDateMin = c.Calibrated95CalendarDateMin;
            newC.Calibrated95CalendarDateSpan = (int)Math.Abs((decimal)(newC.Calibrated95CalendarDateMax) - (decimal)(newC.Calibrated95CalendarDateMin));
            decimal decAvg;
            int Avg;
            decAvg = ((decimal)newC.Calibrated95CalendarDateMax + (decimal)newC.Calibrated95CalendarDateMin) / 2;
            //Avg = (int)Math.Ceiling(Math.Abs(((decimal)c.Calibrated95CalendarDateMax + (decimal)c.Calibrated95CalendarDateMin) / 2));
            if (decAvg < 0)
            {
                Avg = (int)Math.Abs(Math.Floor(decAvg));
                newC.Calibrated95CalendarDateAvg = Avg + " BC";
            }
            else if (decAvg > 0)
            {
                Avg = (int)Math.Ceiling(decAvg);
                newC.Calibrated95CalendarDateAvg = Avg + "";
            }
            else
            {
                newC.Calibrated95CalendarDateAvg = "0";
            }
            newC.Category = c.Category;
            newC.Notes = c.Notes;
            context.SaveChanges();
            return RedirectToAction("C14Sample", new { BurialId = c.BurialId });
        }
        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public IActionResult DeleteC14Sample(int C14Id)
        {
            C14Sample c = context.C14Sample.Single(c => c.C14SampleId == C14Id);
            context.C14Sample.Remove(c);
            context.SaveChanges();
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
