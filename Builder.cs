using System;
using System.Collections.Generic;

namespace Programm
{

    public interface IBuilder
    {
        void PresidentRussia();

        void PresidentUSA();

        void PresidentUkrain();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void PresidentRussia()
        {
            this._product.Add("Путин");
        }

        public void PresidentUSA()
        {
            this._product.Add("Байден");
        }

        public void PresidentUkrain()
        {
            this._product.Add("Зеленский");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }


    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMinimalViableProduct()
        {
            this._builder.PresidentRussia();
        }

        public void BuildFullFeaturedProduct()
        {
            this._builder.PresidentRussia();
            this._builder.PresidentUSA();
            this._builder.PresidentUkrain();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Только Путин и никто другой!");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Президенты:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Без президента США:");
            builder.PresidentRussia();
            builder.PresidentUkrain();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}