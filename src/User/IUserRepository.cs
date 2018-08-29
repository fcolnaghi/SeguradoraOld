using System.Collections.Generic;
using Seguradora.User;

namespace Seguradora.User
{
    public interface IUserRepository
    {
        User GetById(int id);
        HashSet<User> GetAll();
        void Delete(int id);
        string Save(User user);
    }
}