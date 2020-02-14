using System.Threading.Tasks;
using TicTacToeApp.Models;

namespace TicTacToeApp.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(UserModel userModel);
    }
}