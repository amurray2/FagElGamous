using FagElGamous.Areas.Identity.Data;
using FagElGamous.Data;
using FagElGamous.Models;
using FagElGamous.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Controllers
{
    public class UserController : Controller
    {

        private UserLoginContext context;
        private readonly UserManager<FagElGamousUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserLoginContext con, RoleManager<IdentityRole> roleManager, UserManager<FagElGamousUser> userManager)
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


        //superUser delete account
        //[Authorize(Policy = "adminPolicy")]
        //[HttpPost]
        //public IActionResult deleteUser(string userId)
        //{
        //    FagElGamousUser usr = context.Users.Find(userId);
        //    context.Users.Remove(usr);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
