using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Shopping_Cart_API.Controllers;
using Shopping_Cart_API.DTOs;
using Shopping_Cart_API.Interfaces;
using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Tests
{
    public class UserControllerTests
    {
        private readonly IUserRepository _userRepository;
        public UserControllerTests()
        {
            _userRepository = A.Fake<IUserRepository>();

        }

        [Fact]
        public void UserController_GetUser_ReturnOk()
        {
            string username = "username";
            var fakeUser = A.Fake<User>();
            A.CallTo(() => _userRepository.GetUser(username)).Returns(fakeUser);
            var controller = new UserController(_userRepository);
            var result = controller.GetUser(username);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void UserController_VerifyUser_ReturnOk()
        {
            string username = "username";
            string password = "password";
            var fakeUser = A.Fake<User>();
            fakeUser.Username = username;
            fakeUser.Password = password;
            A.CallTo(() => _userRepository.GetUser(username)).Returns(fakeUser);

            var fakePayload = A.Fake<ValidatedUserDTO>();
            fakePayload.Username = username;
            fakePayload.Password = password;

            var controller = new UserController(_userRepository);
            var result = controller.VerifyUser(fakePayload);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkResult));
        }

        [Fact]
        public void UserController_VerifyUser_ReturnUnauthorized()
        {
            string username = "username";
            string password = "password";
            var fakeUser = A.Fake<User>();
            fakeUser.Username = username;
            fakeUser.Password = password;
            A.CallTo(() => _userRepository.GetUser(username)).Returns(fakeUser);

            var fakePayload = A.Fake<ValidatedUserDTO>();
            fakePayload.Username = username;
            fakePayload.Password = "wrong password";

            var controller = new UserController(_userRepository);
            var result = controller.VerifyUser(fakePayload);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(UnauthorizedResult));
        }

        [Fact]
        public void UserController_AddNewItem_ReturnOk()
        {
            A.CallTo(() => _userRepository.AddNewItem(1, 1)).DoesNothing();

            var fakePayload = A.Fake<ItemUserDTO>();
            fakePayload.ItemId = 1;
            fakePayload.UserId = 1;

            var controller = new UserController(_userRepository);
            var result = controller.AddNewItem(fakePayload);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkResult));
        }

        [Fact]
        public void UserController_RemoveItem_ReturnOk()
        {
            A.CallTo(() => _userRepository.RemoveItem(1, 1)).DoesNothing();

            var fakePayload = A.Fake<ItemUserDTO>();
            fakePayload.ItemId = 1;
            fakePayload.UserId = 1;

            var controller = new UserController(_userRepository);
            var result = controller.RemoveItem(fakePayload);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkResult));
        }

        [Fact]
        public void UserController_IncrementItem_ReturnOk()
        {
            A.CallTo(() => _userRepository.IncrementItem(1, 1)).DoesNothing();

            var fakePayload = A.Fake<ItemUserDTO>();
            fakePayload.ItemId = 1;
            fakePayload.UserId = 1;

            var controller = new UserController(_userRepository);
            var result = controller.IncrementItem(fakePayload);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkResult));
        }

        [Fact]
        public void UserController_DecrementItem_ReturnOk()
        {
            A.CallTo(() => _userRepository.DecrementItem(1, 1)).DoesNothing();

            var fakePayload = A.Fake<ItemUserDTO>();
            fakePayload.ItemId = 1;
            fakePayload.UserId = 1;

            var controller = new UserController(_userRepository);
            var result = controller.DecrementItem(fakePayload);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkResult));
        }

        [Fact]
        public void UserController_ClearCart_ReturnOk()
        {
            A.CallTo(() => _userRepository.ClearCart(1)).DoesNothing();

            var fakePayload = A.Fake<UserIDDTO>();
            fakePayload.Id = 1;

            var controller = new UserController(_userRepository);
            var result = controller.ClearCart(fakePayload);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkResult));
        }

    }

}
