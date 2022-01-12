using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship state = new Ship(4, "Корабль", new Cruiser());
            state.style();
            state.fstyle = new Battleship();
            state.style();

            Console.ReadLine();
        }
    }
    interface fstyle
    {
        void style();
    }

    class Cruiser : fstyle
    {
        public void style()
        {
            Console.WriteLine("Крейсер Аврора");
        }
    }

    class Battleship : fstyle
    {
        public void style()
        {
            Console.WriteLine("Адмирал Кузнецов");
        }
    }
    class Ship
    {
        protected int destiny; 
        protected string type; 

        public Ship(int num, string name, fstyle kind)
        {
            this.destiny = num;
            this.type = name;
            fstyle = kind;
        }
        public fstyle fstyle { private get; set; }
        public void style()
        {
            fstyle.style();
        }
    }
}
