using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        protected UserService userService { get; set; }

        public AddFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            try
            {
                Console.WriteLine("Введите email пользователя которого хотите добавить в друзья :");

                UserAddFriendData userAddingFriendData = new UserAddFriendData();
                userAddingFriendData.FriendEmail = Console.ReadLine();
                userAddingFriendData.UserId = user.Id;

                userService.AddFriend(userAddingFriendData);

                SuccessMessage.Show("Пользователь был успешно добавлен в друзья.");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с данным email не существует!");
            }
        }
    }
}
