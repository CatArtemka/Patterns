using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            double BaseClockP = 3200;
            double TemperatureP = 60;
            double BaseClock = 3400;
            double Temperature = 72;

            CPUFactory cpufactory = new CPUFactory();
            for (int i = 0; i < 2; i++)
            {
                CPU AMD = cpufactory.GetCPU("AMD");
                if (AMD != null)
                    AMD.Build(BaseClock, Temperature);
                BaseClock += 100;
                Temperature += 8;
            }

            for (int i = 0; i < 2; i++)
            {
                CPU intel = cpufactory.GetCPU("Intel");
                if (intel != null)
                    intel.Build(BaseClockP, TemperatureP);
                BaseClockP += 70;
                TemperatureP += 4;
            }

            Console.Read();
        }
    }

    abstract class CPU
    {
        protected int architecture;

        public abstract void Build(double BaseClock, double Temperature);
    }

    class AMD : CPU
    {
        public AMD()
        {
            architecture = 3;
        }

        public override void Build(double BaseClock, double Temperature)
        {
            Console.WriteLine("Процессор от AMD, с базовой частотой {0} и температурой {1} имеет 6 ядер и 12 потоков",
                BaseClock, Temperature);
        }
    }
    class intel : CPU
    {
        public intel()
        {
            architecture = 2;
        }

        public override void Build(double BaseClockP, double TemperatureP)
        {
            Console.WriteLine("Процессор от Intel, с базовой частотой {0} и температурой {1} имеет 4 ядра и 8 потоков",
                BaseClockP, TemperatureP);
        }
    }

    class CPUFactory
    {
        readonly Dictionary<string, CPU> cards = new Dictionary<string, CPU>();
        public CPUFactory()
        {
            cards.Add("Intel", new intel());
            cards.Add("AMD", new AMD());
        }

        public CPU GetCPU(string key)
        {
            if (cards.ContainsKey(key))
                return cards[key];
            else
                return null;
        }
    }
}