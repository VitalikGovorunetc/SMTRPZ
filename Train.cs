using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TRPZ_Lab
{
    public class Train
    {
        public int Speed { get; set; }
        public bool Running { get; set; }
        public int Ostanovka { get; set; }
        public List<Passangers> Passangers { get; set; }= new List<Passangers>();

        public void Addpass(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.Passangers.Add(new Passangers());
            }
        }

        public void Removepass(int amount)
        {
            try
            {
                if (this.Running) throw new Exception("Поезд в пути!");
                for (int i = 0; i < amount; i++)
                {
                    this.Passangers.Remove(this.Passangers.Last());
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Run()
        {
            if(this.Running) throw new Exception("Остановись прежде чем поехать");
            this.Running = true;
            this.Speed = 5;
        }

        public void Stop()
        {
            if(this.Speed > 20) throw new Exception("Поезд не может остановить если скорость больше 20 km/h");
            this.Running = false;
            this.Speed = 0;
            this.Ostanovka++;
        }

        public void SpeedUp(int amount)
        {
            if(amount > 10) throw new Exception("Поезд не может изменить скорость больше чем на 10 km/h");
            this.Speed += amount;
        }

        public void SpeedDown(int amount)
        {
            if (amount > 10) throw new Exception("Поезд не может изменить скорость больше чем на 10 km/h");
            if(this.Speed - amount < 3) throw new Exception("Поезд не может ехать со скоростю ниже 3 km/h");
            this.Speed -= amount;
        }
    }
}