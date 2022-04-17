using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;
using BLOGN.SharedTools;
using Microsoft.Extensions.Options;
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
        private readonly AppSettings _appSettings;
        public UserRepository(ApplicationDbContext context,IOptions<AppSettings> appSettings) : base(context)
        {
            _context = context;
            _appSettings = appSettings.Value;
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
