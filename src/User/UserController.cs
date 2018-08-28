using Microsoft.AspNetCore.Mvc;
using System;

namespace Seguradora.User
{

    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("/user/{id}")]
        public string GetUser(int id)
        {
            return "BATATA";
        }

    }

}