using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Shopping_Cart_API.Controllers;
using Shopping_Cart_API.Interfaces;
using Shopping_Cart_API.Models;
using Xunit;

namespace Shopping_Cart_API.tests
{
    public class ItemControllerTests
    {
        private readonly IItemRepository _itemRepository;
        public ItemControllerTests()
        {
            _itemRepository = A.Fake<IItemRepository>();

        }

        [Fact]
        public void ItemController_GetItems_ReturnOk()
        {
            var controller = new ItemsController(_itemRepository);
            var result = controller.GetItems();
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ItemController_GetItemsByUser_ReturnOk()
        {
            int userId = 1;
            var fakeItems = A.Fake<ICollection<Item>>();
            A.CallTo(() => _itemRepository.GetItemsByUser(userId)).Returns(fakeItems);
            var controller = new ItemsController(_itemRepository);
            var result = controller.GetItemsByUser(userId);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));

        }



    }
}