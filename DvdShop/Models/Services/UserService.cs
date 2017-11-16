using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvdShop.Models.Entities;

namespace DvdShop.Models.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User GetInfoUser(string username,string pass);
    }
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
           _userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
        }

        public User GetInfoUser(string username,string pass)
        {
            return _userRepository.GetWithCondition(x => x.Status  && x.UserName == username && x.Password == pass);
        }
    }
}