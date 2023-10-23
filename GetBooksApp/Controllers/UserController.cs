using AutoMapper;
using GetBooksApp.Dtos;
using GetBooksApp.Interfaces;
using GetBooksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetBooksApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserData _userData;
        private readonly IMapper _mapper;

        public UserController(IUserData userData, IMapper mapper)
        {
            _userData = userData ?? throw new ArgumentNullException(nameof(userData));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))]

        public IActionResult GetBooks()
        {
            var users = _mapper.Map<List<UserDto>>(_userData.GetUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateBook([FromBody] UserForCreationDto userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest();
            }

            var user = _userData.GetUsers().Where(c => c.UserName.Trim().ToLower() == userCreate.UserName.ToLower()).FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "Username Already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userMap = _mapper.Map<UserModel>(userCreate);

            if (!_userData.AddUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while creating");
                return StatusCode(500, ModelState);
            }
            return Ok("User Successfully created");
        }

    }
}
