using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Aliexpress eshop = new Aliexpress();
            Buy thing = new Buy();
            time month = new time();

            Facade ide = new Facade(eshop, thing, month);

            Programmer programmer = new Programmer();
            programmer.CreateApplication(ide);

            Console.Read();
        }
    }
    class Aliexpress
    {
        public void Enter()
        {
            Console.WriteLine("Зайти в интеренет магазин");
        }
        public void Order()
        {
            Console.WriteLine("Выбрать товар и добавить его в корзину");
        }
    }
    class Buy
    {
        public void Checkout()
        {
            Console.WriteLine("Рассплатиться онлайн");
        }
    }
    class time
    {
        public void Wait()
        {
            Console.WriteLine("Подождать месяц");
        }
        public void Pochta()
        {
            Console.WriteLine("Забрать посылку с почты");
        }
    }

    class Facade
    {
        Aliexpress eshop;
        Buy compiller;
        time month;
        public Facade(Aliexpress te, Buy compil, time month)
        {
            this.eshop = te;
            this.compiller = compil;
            this.month = month;
        }
        public void Start()
        {
            eshop.Enter();
            eshop.Order();
            compiller.Checkout();
            month.Wait();
        }
        public void Stop()
        {
            month.Pochta();
        }
    }

    class Programmer
    {
        public void CreateApplication(Facade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
