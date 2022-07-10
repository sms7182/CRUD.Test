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
            return new ResponseDto();
        }
    }
}
