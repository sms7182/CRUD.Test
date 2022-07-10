using Car.Application.BaseCommandQueryHandler;
using Car.Application.Dtos;
using Car.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.CarServices.Commands
{
    public class CreateCarCommandHandler : BaseCommandHandler<CreateCarCommand, CarDto, ResponseDto>
    {
        private readonly CarDbContext _carDbContext;

        public CreateCarCommandHandler(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }
        public override async Task<ResponseDto> Handler(CreateCarCommand request, CancellationToken cancellationToken = default)
        {
            var dto = request.RequestDto;
            var car= Domain.Car.CreateCar(dto.Brand, dto.Model, dto.Navigation);
           await _carDbContext.Cars.AddAsync(car, cancellationToken);
           await _carDbContext.SaveChangesAsync(cancellationToken);
           return new ResponseDto() { IsSuccess=true};
        }
    }
}
