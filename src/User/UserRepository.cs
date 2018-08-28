using System.Collections.Generic;
using Seguradora.User;
using System;

namespace Seguradora.User
{
    public class UserRepository : IUserRepository
    {
        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new System.NotImplementedException();
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