using System;
using Microsoft.AspNetCore.Mvc;

namespace Seguradora.User {

    [Route ("api/[controller]")]
    public class UserController : Controller {

        private readonly IUserRepository _userRepository;

        public UserController (IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult List () {
            return Ok (_userRepository.GetAll ());
        }

        [HttpGet ("{id}")] // Matches '/api/user/{id}'
        public IActionResult Get (int id) {
            return Ok (_userRepository.GetById (id));
        }

        [HttpDelete ("{id}")] // Matches '/api/user/{id}'
        public IActionResult Delete (int id) {
            _userRepository.Delete (id);
            return Ok ("{ 'msg': 'Usuario removido com sucesso!'}");
        }

        [HttpPost ("{id}")] // Matches '/api/user/{id}'
        public IActionResult Save (User user) {
            return Ok (_userRepository.Save (user));
        }
    }

}