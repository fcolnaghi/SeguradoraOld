using System;
using System.Security.Cryptography;
using System.Text;
using Seguradora.src.Auth;
using Seguradora.src.User;

namespace Seguradora.src.User {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;

        public UserService (IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        protected string GenerateHashPassword (string password) {
            using (var sha256 = SHA256.Create ()) {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash (Encoding.UTF8.GetBytes (password));
                // Get the hashed string.  
                return BitConverter.ToString (hashedBytes).Replace ("-", "").ToLower ();
            }
        }

        public User GetByAuth (Login auth) {
            return _userRepository.GetByAuth (auth);
        }

        public User Save (User user) {

            user.Password = GenerateHashPassword (user.Password);

            return _userRepository.Save (user);
        }
    }
}