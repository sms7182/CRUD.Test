using Car.Application.BaseCommandQuery;
using Car.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.CarServices.Commands
{
    public class CreateCarCommand:BaseCommand<CarDto,ResponseDto>
    {
    }
}
