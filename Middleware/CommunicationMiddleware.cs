using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TicTacToeApp.Middleware
{
    public class CommunicationMiddleware
    {

        private readonly Microsoft.AspNetCore.Http.RequestDelegate _next;
        private readonly Services.IUserService _userService;
        public CommunicationMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next,
        Services.IUserService userService)
        {
            _next = next;
            _userService = userService;
        }
        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {
            if (context.Request.Path.Equals("/CheckEmailConfirmationStatus"))
            {
                await ProcessEmailConfirmation(context);
            }
            else
            {
                await _next?.Invoke(context);
            }
        }

        private async Task ProcessEmailConfirmation(Microsoft.AspNetCore.Http.HttpContext context)
        {
            var email = context.Request.Query["email"];
            var user = await _userService.GetUserByEmail(email);
            if (string.IsNullOrEmpty(email))
            {
                await context.Response.WriteAsync("BadRequest:Email is required");
            }
            else if (
            (await _userService.GetUserByEmail(email)).IsEmailConfirmed)
            {
                await context.Response.WriteAsync("OK");
            }
            else
            {
                await context.Response.WriteAsync(
                "WaitingForEmailConfirmation");
                user.IsEmailConfirmed = true;
                user.EmailConfirmationDate = DateTime.Now;
                _userService.UpdateUser(user).Wait();
            }
        }
    }
}
