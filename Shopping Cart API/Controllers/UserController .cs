using Microsoft.AspNetCore.Mvc;
using Shopping_Cart_API.DTOs;
using Shopping_Cart_API.Interfaces;


namespace Shopping_Cart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }
        [HttpGet("{username}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetUser(string username) {
            var user = _userRepository.GetUser(username);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        
        }

        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        public IActionResult VerifyUser([FromBody] ValidatedUserDTO userDto) 
        {
            string username = userDto.Username;
            string password = userDto.Password;

            var user = _userRepository.GetUser(username);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            else if (user != null)
            {
                if (user.Password == password)
                {
                    return Ok();
                }

            } 
           return Unauthorized();

            




        }

        [HttpPut("cart/new")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddNewItem([FromBody] ItemUserDTO itemUserDto)
        {
            int userId = itemUserDto.UserId;
            int itemId = itemUserDto.ItemId;

            _userRepository.AddNewItem(userId, itemId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();


        }

        [HttpPut("cart/remove")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult RemoveItem([FromBody] ItemUserDTO itemUserDto)
        {
            int userId = itemUserDto.UserId;
            int itemId = itemUserDto.ItemId;

            _userRepository.RemoveItem(userId, itemId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPut("cart/increment")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult IncrementItem([FromBody] ItemUserDTO itemUserDto)
        {
            int userId = itemUserDto.UserId;
            int itemId = itemUserDto.ItemId;

            _userRepository.IncrementItem(userId, itemId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPut("cart/decrement")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DecrementItem([FromBody] ItemUserDTO itemUserDto)
        {
            int userId = itemUserDto.UserId;
            int itemId = itemUserDto.ItemId;

            _userRepository.DecrementItem(userId, itemId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPut("cart/clear")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult ClearCart([FromBody] UserIDDTO userIdObject)
        {
            int userId = userIdObject.Id;
            _userRepository.ClearCart(userId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
