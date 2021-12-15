using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendView
    {
        protected List<User> friends { get; set; }

        public void Show(IEnumerable<User> friends)
        {
            Console.WriteLine("Мои друзья");

            this.friends = friends.ToList();

            if (friends.Count() == 0)
            {
                Console.WriteLine("Вы ещё не добавили друзей.");
                return;
            }

            foreach (var friend in friends)
            {
                Console.WriteLine("Почтовый адрес друга : {0} || Имя друга : {1} || Фамилия друга : {2}", friend.Email, friend.FirstName, friend.LastName);
            }
        }

    }
}

