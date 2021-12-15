using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkTests
{

    internal class AddFriendTest
    {
        protected UserService userService { get; set; }
        protected User user { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.userService = new UserService();

            var authenticationData = new UserAuthenticationData();
            authenticationData.Email = "email1@mail.com";
            authenticationData.Password = "12345";
            this.user = this.userService.Authenticate(authenticationData);
        }

        [Test]
        public void AddFriend()
        {
            try
            {
                UserAddFriendData userAddingFriendData = new UserAddFriendData();
                userAddingFriendData.FriendEmail = "email2@mail.com";
                userAddingFriendData.UserId = user.Id;

                userService.AddFriend(userAddingFriendData);

                Assert.IsTrue(true, "User was been added to database");
            }
            catch (UserNotFoundException)
            {
                Assert.IsFalse(true, "UserNotFoundException");
            }
        }

        [Test]
        public void Show()
        {
            List<User> friends = user.Friends.ToList();

            if (friends.Count() == 0)
            {
                Assert.IsFalse(true, "friends count less then 1");
            }
            else if (friends.Count() > 0)
            {
                Assert.IsTrue(true, "friends count more then 0");
            }
        }
    }
}
