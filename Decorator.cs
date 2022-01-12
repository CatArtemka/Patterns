using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            PC pcair = new Pc();
            pcair = new PCFull(pcair);
            Console.WriteLine("Название: {0}", pcair.Name);
            Console.WriteLine("Цена: {0}", pcair.GetCost());

            PC pcwater = new Pc();
            pcwater = new Pcwaterair(pcwater);
            Console.WriteLine("Название: {0}", pcwater.Name);
            Console.WriteLine("Цена: {0}", pcwater.GetCost());

            PC Vcar = new Pc1();
            Vcar = new PCFull(Vcar);
            Vcar = new Pcwaterair(Vcar);
            Console.WriteLine("Название: {0}", Vcar.Name);
            Console.WriteLine("Цена: {0}", Vcar.GetCost());

            Console.ReadLine();
        }
    }

    abstract class PC
    {
        public PC(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class Pc : PC
    {
        public Pc() : base("PC")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class Pc1 : PC
    {
        public Pc1()
            : base("PCall")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class PCDecor : PC
    {
        protected PC numbers;
        public PCDecor(string n, PC number) : base(n)
        {
            this.numbers = number;
        }
    }

    class PCFull : PCDecor
    {
        public PCFull(PC p)
            : base(p.Name + ", с водяным охлаждением процессора", p)
        { }

        public override int GetCost()
        {
            return numbers.GetCost() + 45;
        }
    }

    class Pcwaterair : PCDecor
    {
        public Pcwaterair(PC p)
            : base(p.Name + ", с водяным охлаждением видеокарты ", p)
        { }

        public override int GetCost()
        {
            return numbers.GetCost() + 75;
        }
    }
}