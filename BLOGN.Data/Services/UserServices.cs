using BLOGN.Data.Repositories.IRepository;
using BLOGN.Data.Services.IServices;
using BLOGN.Data.UnitOfWork;
using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Services
{
    public class UserServices : Services<User>, IUserServices
    {
        public UserServices(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {
        }
    }
}
