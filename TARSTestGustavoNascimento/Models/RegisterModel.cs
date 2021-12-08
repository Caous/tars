

using System.ComponentModel.DataAnnotations;

namespace TARSTestGustavoNascimento.Models
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string fullname { get; set; }
        public string departament { get; set; }
        public string Email { get; set; }

        public string TitlePage { get; set; }
        public string btnValue { get; set; }

    }
}