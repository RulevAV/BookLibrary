using BookLibrary.Domain.Entities;
using System.Collections.Generic;

namespace BookLibrary.Domain.Repositories.Abstract
{
    public interface IUser
    {
        public List<user> getAllUsers();
        public user findUser(string Email, string Password);
        public user RegisterUser(string Email, string Password, string Username);
    }
}
