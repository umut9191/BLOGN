using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Services.IServices
{
    public interface IUserServices//:IService<User>
    {
        bool IsUniqueUser(string userName);
        User Authenticate(string userName, string password);
        User Register(string userName, string password);
    }
}
