using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Dtos
{
    public class CarResponseDto:ResponseDto<CarResDto>
    {

    }
    public class CarResDto
    {
        public long Id { get; set; }
        public string? Brand{ get; set; }
        public string? Model { get; set; }
        public bool Navigation { get; set; }
    }
}
