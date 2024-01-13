using Microsoft.AspNetCore.Mvc;
using Shopping_Cart_API.Interfaces;


namespace Shopping_Cart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController: Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetItems()
        {
          var items = _itemRepository.GetItems();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(items);

        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetItemsByUser(int userId)
        {
            var items = _itemRepository.GetItemsByUser(userId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(items);

        }

    }
}
