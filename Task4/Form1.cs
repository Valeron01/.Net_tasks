using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        class BaseClass
        {
            protected readonly float income;
            protected readonly float rating;
            protected readonly string name;

            public BaseClass(string name, float income, float rating)
            {
                this.name = name;
                this.income = income;
                this.rating = rating;
            }

            public virtual float Quality()
            {
                return income * rating;
            }

            public override string ToString()
            {
                return "Base class of company " + name + " with Quality " + Quality();
            }
        }


        class ChildClass : BaseClass
        {
            float investment;
            public ChildClass(string name, float income, float rating, float investment) : base(name, income, rating)
            {
                this.investment = investment;
            }

            public override float Quality()
            {
                return (float)Math.Pow(investment, 3) + base.Quality();
            }

            public override string ToString()
            {
                return "Child class of company " + name + " with Quality " + Quality();
            }
        }

        private BaseClass baseClass;
        private ChildClass childClass;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == 0)
            {
                InvestmentText.Enabled = false;
                label4.Enabled = false;
            }
            else
            {
                InvestmentText.Enabled = true;
                label4.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isBase = comboBox1.SelectedIndex == 0;

            string name = NameText.Text;
            float income = 0;
            float rating = 0;
            float investment = 0;
            try
            {
                income = float.Parse(IncomeText.Text);
                rating = float.Parse(RatingText.Text);
                if(!isBase)
                    investment = float.Parse(InvestmentText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте правильность введённых данных!");
            }

            if (isBase)
            {
                baseClass = new BaseClass(name, income, rating);
                MessageBox.Show(baseClass.ToString());
            }

            if (!isBase)
            {
                childClass = new ChildClass(name, income, rating, investment);
                MessageBox.Show(childClass.ToString());
            }
        }
    }
}
