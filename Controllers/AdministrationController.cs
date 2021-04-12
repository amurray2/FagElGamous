using FagElGamous.Areas.Identity.Data;
using FagElGamous.Data;
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
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<FagElGamousUser> userManager;
        private UserLoginContext context;
        public AdministrationController(UserLoginContext con, RoleManager<IdentityRole> roleManager, UserManager<FagElGamousUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            context = con;
        }

        [Authorize(Policy = "adminPolicy")]
        public IActionResult Index()
        {
            return View(context.Users);
        }

        [HttpGet]
        [Authorize(Policy = "adminPolicy")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "adminPolicy")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "adminPolicy")]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }


        [Authorize(Policy = "adminPolicy")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
           var role = await roleManager.FindByIdAsync(id);

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach(var user in userManager.Users.ToList())
            {
               if( await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName); //maybe userFIrstName instead
                }
            }

            return View(model);
        }

        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            role.Name = model.RoleName;
            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [Authorize(Policy = "adminPolicy")]
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            //create instance of userviewmodel clas
            var model = new List<UserRoleViewModel>();

            foreach(var user in userManager.Users.ToList())
            {
                var UserRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    userName = user.UserName
                };

                //check if the user is already in this role
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    UserRoleViewModel.IsSelected = true;
                }
                else
                {
                    UserRoleViewModel.IsSelected = false;
                }

                model.Add(UserRoleViewModel);
            }

            return View(model);
        }

        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            //loop through each object in the UserRoleViewModel
            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;

                //if the user is selected and isn't already in that role, add them to the role
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                //if the user is not selected but is currently in that role, remove them from the role
                else if(!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                //otherwise, continue looping
                else
                {
                    continue;
                }

                //check to see if the adding and removing went through properly
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        //delete role
        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public async Task<IActionResult> deleteRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            var result = await roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("ListRoles");
        }

        //Edit user
        [Authorize(Policy = "adminPolicy")]
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var userRoles = await userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                //Email = user.Email,
                UserName = user.UserName,
                Roles = userRoles
            };

            return View(model);
        }

        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            user.UserName = model.UserName;
            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        //delete user
        [Authorize(Policy = "adminPolicy")]
        [HttpPost]
        public IActionResult deleteUser(string userId)
        {
            FagElGamousUser usr = context.Users.Find(userId);
            context.Users.Remove(usr);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Authorize(Policy = "adminPolicy")]
        //[HttpPost]
        //public async Task<IActionResult> EditUser(EditUserViewModel model)
        //{
        //    var user = await userManager.FindByIdAsync(model.Id);

        //    user.UserName = model.UserName;
        //    var result = await userManager.UpdateAsync(user);

        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("/User/Index");
        //    }

        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error.Description);
        //    }

        //    return View(model);
        //}
    }
}
