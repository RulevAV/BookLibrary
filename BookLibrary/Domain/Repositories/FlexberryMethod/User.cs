using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Repositories.Abstract;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BookLibrary.Domain.Repositories.FlexberryMethod
{
    public class User : IUser
    {
        SQLDataService ds = (SQLDataService)DataServiceProvider.DataService;

        public List<user> getAllUsers()
        {
            return ds.Query<user>(user.Views.userL).ToList();
        }

        public user findUser(string Email, string Password)
        {
            return ds.Query<user>(user.Views.userL).FirstOrDefault(u => u.email == Email && u.password == Password);
        }
        public user RegisterUser(string Email, string Password, string Username)
        {
            var User = ds.Query<user>(user.Views.userL).FirstOrDefault(u => u.email == Email);

            if (User != null)
            {
                return null;
            }

            var _user = new user();
            _user.email = Email;
            _user.password = Password;
            _user.username = Username;

            ds.UpdateObject(_user);//Добавить Объект
            return _user;
        }
        
    }
}
