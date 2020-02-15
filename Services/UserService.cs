using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeApp.Services
{
    public class UserService :IUserService
    {
        private static System.Collections.Concurrent.ConcurrentBag<Models.UserModel> _userStore;
        static UserService()
        {
            _userStore = new System.Collections.Concurrent.ConcurrentBag<Models.UserModel>();
        }
        public Task<bool> RegisterUser(Models.UserModel userModel)
        {
            _userStore.Add(userModel);
            return Task.FromResult(true);
        }
        public Task<Models.UserModel> GetUserByEmail(string email)
        {
            return Task.FromResult(_userStore.FirstOrDefault(
            u => u.Email == email));
        }
        public Task UpdateUser(Models.UserModel userModel)
        {
            _userStore = new System.Collections.Concurrent.ConcurrentBag<Models.UserModel>
            (_userStore.Where(u => u.Email != userModel.Email))
            {
                userModel
            };
            return Task.CompletedTask;
        }
    }
}
