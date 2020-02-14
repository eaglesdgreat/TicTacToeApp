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
            await _userService.RegisterUser(userModel);
            return Content($"User {userModel.FirstName} { userModel.LastName} has been registered sucessfully");
        }
    }
}