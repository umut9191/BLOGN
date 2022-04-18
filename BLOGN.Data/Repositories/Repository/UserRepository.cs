using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;
using BLOGN.SharedTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        private readonly DbSet<User> _dbSet;
        public UserRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _dbSet = _context.Set<User>();
        }

        public User Authenticate(string userName, string password)
        {
            var user = _dbSet.SingleOrDefault(u => u.UserName == userName && u.Password == password);
            if (user == null)
            {
                return null;
            }
            //if it is not null then create new token;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = "";
            return user;
        }

        public bool IsUniqueUser(string userName)
        {
            var user = _dbSet.SingleOrDefault(x=>x.UserName == userName);
            if (user == null)
                return true;//no user found
            return false;// user found

        }

        public User Register(string userName, string password)
        {
            User user = new User()
            {
                UserName = userName,
                Password = password,
                Role = "Admin",
                Cofirmation = false
            };
            _dbSet.Add(user);
           // _context.SaveChanges(); it will used on userService
            user.Password = "";
            return user;
        }
    }
}
