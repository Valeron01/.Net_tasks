using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3_Window
{
    class Coffee
    {
        public readonly float weight;

        public readonly float width;
        public readonly float height;
        public readonly float length;

        public readonly float price;

        public Coffee(float weight, float width, float height, float length, float price)
        {
            this.weight = weight;
            this.width = width;
            this.height = height;
            this.length = length;
            this.price = price;
        }

        public float Volume
        {
            get { return width * height * length; }
        }

        public override string ToString()
        {
            return $"Base coffee, {width}x{length}x{height}, {Volume} cm2, {price} rub";
        }
    }

    class BlackCardCoffee : Coffee
    {
        public BlackCardCoffee() : base(150, 5, 10, 5, 150)
        {

        }
        public override string ToString()
        {
            return $"Black Card Coffee, {width}x{length}x{height}, {Volume} cm2, {price} rub";
        }

    }

    class RoundJarCoffe : Coffee
    {
        public RoundJarCoffe() : base(300, 7, 15, 7, 300)
        {

        }

        public override string ToString()
        {
            return $"Round Jar Coffe, {width}x{length}x{height}, {Volume} cm2, {price} rub";
        }
    }

    class SmallPacketCoffee : Coffee
    {
        public SmallPacketCoffee() : base(3, 2, 10, 2, 30)
        {

        }

        public override string ToString()
        {
            return $"Small Packet Coffee, {width}x{length}x{height}, {Volume} cm2, {price} rub";
        }
    }


    class Van
    {
        private readonly List<Coffee> bag = new List<Coffee>();

        public void addCoffee(Coffee c)
        {
            bag.Add(c);
        }

        public float calcWeight()
        {
            float result = 0;

            foreach (var item in bag)
            {
                result += item.weight;
            }

            return result;
        }

        public float calcPrice()
        {
            float result = 0;

            foreach (var item in bag)
            {
                result += item.price;
            }

            return result;
        }

        public float calcVolume()
        {
            float result = 0;

            foreach (var item in bag)
            {
                result += item.Volume;
            }

            return result;
        }

        public ReadOnlyCollection<Coffee> getBag()
        {
            return new ReadOnlyCollection<Coffee>(bag);
        }
    }


    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
