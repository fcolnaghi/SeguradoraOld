using System;
using System.Collections.Generic;
using System.Linq;
using Seguradora.src.Auth;
using Seguradora.src.User.Context;

namespace Seguradora.src.User {

    public class UserRepository : IUserRepository {
        private readonly MysqlContext _context;

        public UserRepository (MysqlContext context) {
            _context = context;
        }

        public void Delete (int id) {
            var user = _context.Users.Find (id);
            if (user == null) {
                
            }

            _context.Users.Remove (user);
            _context.SaveChanges ();
        }

        public HashSet<User> GetAll () {
            return new HashSet<User> (_context.Users.ToList ());
        }

        public User GetByAuth(Login auth)
        {
            return _context.Users.SingleOrDefault(u => u.Email.Equals(auth.username));
        }

        public User GetById (int id) {
            return _context.Users.Find(id);
        }

        public User Save (User user) {
            if(user.Id > 0) {
                _context.Users.Update(user);
            } else {
                _context.Users.Add(user);
            }
            _context.SaveChanges();

            return user;
        }
    }
}