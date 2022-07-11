
using Car.API.IdentityManager;
using Car.Application;
using Car.Application.CarServices.Commands;
using Car.Application.CarServices.Queries;
using Car.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Car.API.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    [Authorize()]
    public class CarController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public CarController(IMediator mediator,IUserService userService)
        {
           _mediator = mediator;
            _userService = userService;
        }

       
        [HttpPost("createCar")]
        public async Task<ActionResult<ResponseDto>> CreateCar([FromBody]CarDto car,CancellationToken cancellationToken=default)
        {
           return await _mediator.Send(new CreateCarCommand()
            {
                RequestDto = car
            },cancellationToken);
        }

//        [Authorize] 
        [HttpGet("getCars")]
        public async Task<ActionResult<CarResponseDto>> GetCars(CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetCarQuery() { },cancellationToken);
        }

       
    }
}
