using Car.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application
{
    public class CarDto:RequestDto
    {
       
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public bool Navigation { get; set; }
    }
}
