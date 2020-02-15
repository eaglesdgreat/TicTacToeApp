using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToeApp.Controllers
{
    public class UserRegistrationController : Controller
    {
        private Services.IUserService _userService;
        public UserRegistrationController(Services.IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Models.UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUser(userModel);
                return RedirectToAction(nameof(EmailConfirmation),
                new { userModel.Email });
            }
            return View(userModel);
        }
        [HttpGet]
        public async Task<IActionResult> EmailConfirmation(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user?.IsEmailConfirmed == true)
                return RedirectToAction("Index", "GameInvitation",
                new { email = email });
            ViewBag.Email = email;
            user.IsEmailConfirmed = true;
            user.EmailConfirmationDate = DateTime.Now;
            await _userService.UpdateUser(user);
            return View();
        }
    }
}