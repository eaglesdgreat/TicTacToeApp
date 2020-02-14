using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeApp.Services
{
    public class UserService :IUserService
    {
        public Task<bool> RegisterUser(Models.UserModel userModel)
        {
            return Task.FromResult(true);
        }
    }
}
