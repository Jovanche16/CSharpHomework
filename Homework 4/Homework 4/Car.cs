using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver Driver { get; set; }

        public Car(string model, int speed )
        {
            Model = model;
            Speed = speed;
        }
        public int CalculateSpeed(Driver driver)
        {
            if (driver != null)
            {
                return driver.Skill * Speed;
            }
            return 0;
        }
    }
}
