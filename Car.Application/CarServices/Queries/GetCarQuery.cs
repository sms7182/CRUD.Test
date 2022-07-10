using Car.Application.BaseCommandQuery;
using Car.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.CarServices.Queries
{
    public class GetCarQuery:BaseQuery<CarReqDto,CarResponseDto>
    {
    }
}
