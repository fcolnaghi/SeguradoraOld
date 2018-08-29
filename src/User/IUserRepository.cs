using System.Collections.Generic;
using Seguradora.src.Auth;


namespace Seguradora.src.User
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetByAuth(Login auth);
        HashSet<User> GetAll();
        void Delete(int id);
        User Save(User user);
    }
}