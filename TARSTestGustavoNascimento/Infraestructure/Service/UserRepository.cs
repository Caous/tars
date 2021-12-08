using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TARSTestGustavoNascimento.Infraestructure.database;
using TARSTestGustavoNascimento.Infraestructure.Interface;
using TARSTestGustavoNascimento.Models;

namespace TARSTestGustavoNascimento.Infraestructure.Service
{
    public class UserRepository : IUserRepository
    {
        public ApplicationDbContext _context { get; }
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}