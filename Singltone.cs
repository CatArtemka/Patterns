using System;

namespace Singleton
{
    public class User
    {
        static User user;
        protected User()
        {
            Console.WriteLine("Добро пожаловать на портал course.sgu.ru");
        }
        public static User Instance()
        {
            if (user == null)
                user = new User();
            else
                Console.WriteLine("Пользователь уже в сети");
            return user;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            User a = User.Instance();
            User b = User.Instance();
        }
    }
}
