using System.Collections.Generic;
using Seguradora.User;

namespace Seguradora.User
{
    public interface IUserRepository
    {
        User GetById(int id);
        List<User> GetAll();
        void Delete();
        string Save(User user);
    }
}