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
    public class UserServices :  IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public UserServices(IUnitOfWork unitOfWork, IUserRepository userRepository) 
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public User Authenticate(string userName, string password)
        {
            var user  = _userRepository.Authenticate(userName,password);
            return user;
        }

        public bool IsUniqueUser(string userName)
        {
           return _userRepository.IsUniqueUser(userName);
        }

        public User Register(string userName, string password)
        {
           var user = _userRepository.Register(userName,password);
            _unitOfWork.Save();
            return user;
        }
    }
}
