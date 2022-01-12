using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {

            Man man = new Man();
            Airplane airplane = new Airplane();
            man.Travel(airplane);
            Fighter fighters = new Fighter();
            // используем адаптер
            ITransport helTransport = new HelToTransportAdapter(fighters);
            man.Travel(helTransport);
            Console.Read();
        }
    }
    interface ITransport
    {
        void Man();
    }

    class Airplane : ITransport
    {
        public void Man()
        {
            Console.WriteLine("Самолет влетел в зону турбулентности");
        }
    }
    class Man
    {
        public void Travel(ITransport transport)
        {
            transport.Man();
        }
    }
    // интерфейс истребителя
    interface Ifighter
    {
        void Move();
    }
    class Fighter : Ifighter
    {
        public void Move()
        {
            Console.WriteLine("Истребитель летит над Семеновкой");
        }
    }
    // Адаптер от Fighter к ITransport
    class HelToTransportAdapter : ITransport
    {
        Fighter fighters;
        public HelToTransportAdapter(Fighter c)
        {
            fighters = c;
        }

        public void Man()
        {
            fighters.Move();
        }
    }
}