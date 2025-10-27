using Interface_Сабитов.Interfaces;
using Interface_Сабитов.Models;
using System.Collections.Generic;

namespace Interface_Сабитов.Classes
{
    public class UsersContext : Users, IUsers
    {
        public List<Users> AllUsers;
        public UsersContext() => this.All(out AllUsers);
        public void All(out List<Users> Users)
        {
            Users = new List<Users>()
            {
                  new Users(1, "Аликина Ольга"),
                  new Users(2, "Бояркин Данил"),
                  new Users(3, "Бурмантов Владислав"),
                  new Users(4, "Дылдин Максим"),
                  new Users(5, "Евдокимов Даниил"),
                  new Users(6, "Костюнин Никита"),
                  new Users(7, "Кучин Данил"),
                  new Users(9, "Мотырев Александр"),
                  new Users(10, "Мухридинов Далер"),
                  new Users(11, "Олейник Владимир"),
                  new Users(12, "Саблин Константин"),
                  new Users(13, "Субботин Валерий"),
                  new Users(14, "Сукрушев Егор"),
                  new Users(15, "Торсунов Даниил"),
                  new Users(16, "Хабибрахманов Никита"),
                  new Users(17, "Хикматулин Григорий"),
                  new Users(18, "Черенев Сергей"),
                  new Users(19, "Чупин Дмитрий"),
                  new Users(20, "Шилов Дмитрий"),
            };
        }
    }
}
