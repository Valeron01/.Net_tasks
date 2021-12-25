using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        public interface IShip
        {
            void Load(float mass);
            string Sail();
            float MaxWeight();
            float Weight();
        }

        public abstract class Warship : IShip
        {
            protected readonly float maxWeight = 0;
            protected float currentWeight = 0;
            protected int weaponsCount;

            public Warship(float maxWeight, int weaponsCount)
            {
                this.maxWeight = maxWeight;
                this.weaponsCount = weaponsCount;
            }

            public abstract void Load(float mass);
            public virtual string Sail()
            {
                return $"Военный корабль массой {currentWeight} отплыл";
            }

            public virtual string LaunchProjectile()
            {
                currentWeight -= 0.01f * currentWeight;
                return $"Снаряд из военного корабля запущен! текущая масса: {currentWeight}";
            }

            public virtual float ProjectileMass()
            {
                return currentWeight * 0.9f;
            }

            public float MaxWeight()
            {
                return maxWeight;
            }

            public int WeaponsCount()
            {
                return weaponsCount;
            }

            public float Weight()
            {
                return this.currentWeight;
            }
        }

        public class Aircraft : Warship
        {
            public Aircraft(float maxWeight): base(maxWeight, 10)
            {

            }

            public override void Load(float planesCount)
            {
                currentWeight += planesCount * 1.1f * 500;
            }

            public void LaunchPLane()
            {
                currentWeight -= 500f;
            }

            public float GasolineMass()
            {
                return currentWeight * 0.1f;
            }

            public float PlaneProjectileMass()
            {
                return currentWeight * 0.004f;
            }
        }


        readonly Random r;
        List<IShip> Navy;
        public Form1()
        {
            InitializeComponent();
             r = new Random();
            Navy = CreateAirCrafts(r.Next(4, 7));

            LoggerLabel.Text = $"Создан военный флот с количеством кораблей {Navy.Count}, загружаем: \n";

            LoadAircrafts(Navy);
            LoggerLabel.Text += "\nОтплываем: \n";
            Sail(Navy);
            LoggerLabel.Text += "\nНачинается запуск самолётов!\n";
            LaunchPlanes(Navy);
            LoggerLabel.Text += "\nНачинается запуск снарядов!\n";
            LaunchProjectiles(Navy);

        }

        public void Sail(List<IShip> ships)
        {
            for (int i = 0; i < ships.Count(); i++)
            {
                var ship = ships[i];

                LoggerLabel.Text += $"Корабль c индексом {i} отплыл, начальная масса: {ship.Weight()}\n";
            }
        }

        public List<IShip> CreateAirCrafts(int count)
        {
            List<IShip> ships = new List<IShip>(count);

            for (int i = 0; i < count; i++)
            {
                float aircraftsCount = (float)(r.NextDouble() + 0.3) * 10f * 500;
                ships.Add(new Aircraft(aircraftsCount));
            }

            return ships;
        }

        public void LoadAircrafts(List<IShip> ships)
        {
            for(int i = 0; i < ships.Count(); i++)
            {
                var ship = ships[i];
                LoggerLabel.Text += $"\n\nНачинается загрузка корабля с индексом {i}\n";
                while(ship.Weight() < ship.MaxWeight())
                {
                    float planeCount = r.Next(1, 2);
                    if (ship.Weight() + planeCount * 500f > ship.MaxWeight())
                        break;
                    ship.Load(planeCount);
                    LoggerLabel.Text += $"В Корабль с индексом {i} загружено самолётов: {planeCount}, масса груза: {ship.Weight()} / {ship.MaxWeight()}\n";
                }
            }
        }

        public void LaunchPlanes(List<IShip> ships)
        {
            for (int i = 0; i < ships.Count(); i++)
            {
                Aircraft ship = (Aircraft)ships[i];

                for(int j = 0; j < ship.Weight() / 500; j++)
                {
                    LoggerLabel.Text += $"Корабль c индексом {i} запсутил самолёт! остаточная масса: {ship.Weight()}\n";
                    ship.LaunchPLane();
                }
            }
        }

        public void LaunchProjectiles(List<IShip> ships)
        {
            for (int i = 0; i < ships.Count(); i++)
            {
                Warship ship = (Warship)ships[i];

                int projectilesCount = r.Next(10, 100);

                for (int j = 0; j < projectilesCount; j++)
                {
                    if (ship.Weight() - 10 < 0)
                    {
                        projectilesCount = j;
                        break;
                    }
                }

                LoggerLabel.Text += $"Корабль c индексом {i} запсутил {projectilesCount} снарядов! остаточная масса: {ship.Weight()}\n";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
