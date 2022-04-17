using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public User Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueUser(string userName)
        {
            throw new NotImplementedException();
        }

        public User Register(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
