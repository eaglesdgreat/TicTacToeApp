using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeApp.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        public string FirstName { get; set; }
        [System.ComponentModel.DataAnnotations.Required()]
        public string LastName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(), System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(), System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public System.DateTime? EmailConfirmationDate { get; set; }
        public int Score { get; set; }
    }
}
