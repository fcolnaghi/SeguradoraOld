using Seguradora.src.Auth;

namespace Seguradora.src.User {
    public interface IUserService {
        User GetByAuth (Login auth);
        User Save(User user);
    }
}