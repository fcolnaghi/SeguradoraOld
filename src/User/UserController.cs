using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Seguradora.src.Auth;

namespace Seguradora.src.User {

    [Route ("api/[controller]")]

    public class UserController : Controller {

        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController (IUserRepository userRepository, IUserService userService) {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        [ServiceFilter (typeof (AuthenticationFilter))]
        public IActionResult GetAll () {
            return new ObjectResult (_userRepository.GetAll ());
        }

        [HttpGet ("{id}")] // Matches '/api/user/{id}'
        public IActionResult Get (int id) {
            User result = _userRepository.GetById (id);
            if (result != null) {
                return new ObjectResult (_userRepository.GetById (id));
            }

            return NotFound ("Usuário não encontrado.");
        }

        [HttpDelete ("{id}")] // Matches '/api/user/{id}'
        public IActionResult Delete (int id) {
            _userRepository.Delete (id);
            return Ok ("Usuario removido com sucesso!");
        }

        [HttpPost] // Matches '/api/user
        public IActionResult Save ([FromBody] User user) {
            if (user == null) {
                return BadRequest ();
            }

            return new ObjectResult (_userService.Save (user));
        }
    }

}