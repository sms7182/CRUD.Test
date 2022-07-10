using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain
{
    public class Car
    {
        public DateTime CreationDate { get;private set; }
        public long Id { get;private set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public bool Navigation { get; set; }

        private Car()
        {
            CreationDate = DateTime.Now;
        }

        public static Car CreateCar(string brand,string model,bool navigation)
        {
            Car car = new ();
            car.Brand = brand;
            car.Model = model;
            car.Navigation = navigation;
            return car;
        }

    }
}
