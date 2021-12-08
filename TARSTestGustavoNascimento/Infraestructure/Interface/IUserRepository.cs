using System.Collections.Generic;
using System.Threading.Tasks;
using TARSTestGustavoNascimento.Models;

namespace TARSTestGustavoNascimento.Infraestructure.Interface
{
    public interface IUserRepository
    {
         Task<IEnumerable<UserModel>> GetAllAsync();
    }
}