using FagElGamous.Areas.Identity.Data;
using FagElGamous.Data;
using FagElGamous.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        private UserLoginContext context;

        public RoleController(RoleManager<IdentityRole> roleManager, UserLoginContext con)
        {
            this.roleManager = roleManager;
            context = con;
        }

        //change to manage accounts page
        [Authorize(Policy = "adminPolicy")]
        public IActionResult Index()
        {
            return View(context.Users);
        }

        //superUser edit account 
        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public IActionResult editUserForm(string userId)
        {
            FagElGamousUser usr = context.Users.Find(userId);
            return View(usr);
        }

        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public IActionResult editUser(FagElGamousUser usr, string userId)
        {
            FagElGamousUser Oldusr = context.Users.Find(userId);
            context.Users.Remove(Oldusr);
            context.Users.Add(usr);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //superUser delete account
        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public IActionResult deleteUser(string userId)
        {
            FagElGamousUser usr = context.Users.Find(userId);
            context.Users.Remove(usr);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        //[Authorize(Policy = "adminPolicy")]
        //public IActionResult Create()
        //{
        //    return View(new IdentityRole());
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(IdentityRole role)
        //{
        //    await roleManager.CreateAsync(role);
        //    return RedirectToAction("Index");
        //}
    }
}
