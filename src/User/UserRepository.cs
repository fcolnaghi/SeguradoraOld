using System.Collections.Generic;
using Seguradora.User;
using System;

namespace Seguradora.User
{
    public class UserRepository : IUserRepository
    {
        public void Delete(int id)
        {
            //throw new System.NotImplementedException();
        }

        public HashSet<User> GetAll()
        {
            HashSet<User> list = new HashSet<User>();
            list.Add(new User());
            list.Add(new User());
            list.Add(new User());
            list.Add(new User());
            list.Add(new User());
            return list;
        }

        public User GetById(int id)
        {
            return new User();
        }

        public string Save(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}