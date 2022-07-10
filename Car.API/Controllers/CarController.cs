using Car.Application;
using Car.Application.CarServices.Commands;
using Car.Application.CarServices.Queries;
using Car.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Car.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController:ControllerBase
    {
        private readonly IMediator _mediator;
        public CarController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpPost("createCar")]
        public async Task<ActionResult<ResponseDto>> CreateCar([FromBody]CarDto car,CancellationToken cancellationToken=default)
        {
           return await _mediator.Send(new CreateCarCommand()
            {
                RequestDto = car
            },cancellationToken);
        }


        [HttpGet("getCars")]
        public async Task<ActionResult<CarResponseDto>> GetCars(CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetCarQuery() { },cancellationToken);
        }
    }
}
