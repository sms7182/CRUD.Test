using Car.Application.BaseCommandQueryHandler;
using Car.Application.Dtos;
using Car.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.CarServices.Queries
{
    public class GetCarQueryHandler : BaseQueryHandler<GetCarQuery, CarReqDto, CarResponseDto>
    {
        private readonly CarDbContext _carDbContext;

        public GetCarQueryHandler(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }
        public override async Task<CarResponseDto> Handler(GetCarQuery request, CancellationToken cancellationToken = default)
        {
          var cars= await  _carDbContext.Cars.ToListAsync(cancellationToken);

            return new CarResponseDto()
            {
                IsSuccess = true,
                Items = cars.Select(x => new CarResDto()
                {
                    Brand = x.Brand,
                    Id = x.Id,
                    Model = x.Model,
                    Navigation = x.Navigation
                }).ToList(),
            };
        }
    }
}
