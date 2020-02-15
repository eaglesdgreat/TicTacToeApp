using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToeApp.Controllers
{
    public class GameInvitationController : Controller
    {
        private Services.IUserService _userService;
        public GameInvitationController(Services.IUserService userService)
        {
            _userService = userService;
        }
        [
      HttpGet]
        public async Task<IActionResult> Index(string email)
        {
            await _userService.GetUserByEmail(email);

            var gameInvitationModel = new Models.GameInvitationModel
            {
                InvitedBy = email
            };
            return View(gameInvitationModel);
        }
    }
}