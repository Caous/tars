using System.ComponentModel.DataAnnotations;

namespace TARSTestGustavoNascimento.Models
{
    public class UserLoginModel
    {
         public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}