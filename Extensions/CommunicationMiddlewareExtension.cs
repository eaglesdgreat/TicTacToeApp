using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeApp.Middleware;

namespace TicTacToeApp.Extensions
{
    public static class CommunicationMiddlewareExtension
    {
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder
        UseCommunicationMiddleware(this Microsoft.AspNetCore.Builder.IApplicationBuilder app)
        {
            return app;
        }
    }
}
