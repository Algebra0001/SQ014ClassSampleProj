using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCSQ014_RazorViews.ViewModels;
using System.Security.Cryptography.Xml;

namespace MVCSQ014_RazorViews.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // redirection condition
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    ModelState.AddModelError("Invalid email", "Email already exists");
                    return View(model);
                }

                var userToAdd = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var addUserResult = await userManager.CreateAsync(userToAdd, model.Password);

                if(addUserResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(userToAdd, "regular");
                    return RedirectToAction("Index", "Home");
                }

                foreach(var err in addUserResult.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (signInManager.IsSignedIn(User))
            {
                RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Invalid Credentials", "Email not recognised!");
                    return View(model);
                }

                //var userToLogin = new IdentityUser
                //{
                //    Email = model.Email
                //};

                var loginResult = await signInManager.PasswordSignInAsync(user, model.Password, 
                                                                            false, false);

                if (loginResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Invalid Credentials", "Password not recognised!");
                return View(model);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                var link = "";
                if(user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    link = Url.Action("ResetPassword", "Account", new { Id = user.Id, token });
                }

                // mail sent
                ViewBag.Link = link;
                return View();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string Id, string token)
        {
            if(string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(token))
            {
                ViewBag.Msg = "Missing credentials for password reset!";
            }

            var resetPasswordVM = new ResetPasswordViewModel
            {
                Id = Id,
                token = token
            };

            return View(resetPasswordVM);  
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.Id);
                if(user == null)
                {
                    ModelState.AddModelError("NotFound", $"User with Id:{model.Id} was not found!");
                    return View(model);
                }

                var result = await userManager.ResetPasswordAsync(user, model.token, model.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach(var err in result.Errors) {
                    ModelState.AddModelError(err.Code, err.Description);
                }

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> ManageUserRoles()
        {
            var userRolesDetails = new UserRolesViewModel();
            var users = userManager.Users.ToList();

            var newList = new List<UserRolesDetail>();

            foreach (var user in users)
            {
                var userrole = await userManager.GetRolesAsync(user);
                userRolesDetails.UserRolesDetails.Add(new UserRolesDetail
                {
                    UserName = user.UserName,
                    IsAdmin = userrole.Any(x => x.Contains("admin")),
                    IsRegular = userrole.Any(x => x.Contains("regular")),
                    IsEitor = userrole.Any(x => x.Contains("editor"))
                });
            }

            return View(userRolesDetails);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> ManageUserRoles(UserRolesViewModel model)
        {
            return View();
        }
    }
}
