using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        //spesific things for users;
        bool IsUniqueUser(string userName);
        User Authenticate(string userName,string password);
        User Register(string userName, string password);

    }
}
