using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3_Window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            Random r = new Random();
            Van van = new Van();


            float maxPrice = 0;
            float maxVolume = 0;

            try
            {
                maxPrice = float.Parse(MaxPrice.Text);

                maxVolume = float.Parse(MaxVolume.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во входных данных!");
            }


            while (van.calcPrice() < maxPrice && van.calcVolume() < maxVolume)
            {
                int coffeeType = r.Next(0, 3);

                switch (coffeeType)
                {
                    case 0:
                        van.addCoffee(new BlackCardCoffee());
                        break;
                    case 1:
                        van.addCoffee(new RoundJarCoffe());
                        break;
                    case 2:
                        van.addCoffee(new SmallPacketCoffee());
                        break;
                }
            }

            foreach (var coffe in van.getBag())
            {
                richTextBox1.Text += coffe.ToString() + "\n";
            }
        }
    }
}
