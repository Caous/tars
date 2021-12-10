using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TARSTestGustavoNascimento.Models
{
    public class UserModel : IdentityUser
    {
        public string fullname { get; set; }
        public string departament { get; set; }
        public DateTime dt_inclused { get; set; }
        public DateTime dt_exclused { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

    }
}
