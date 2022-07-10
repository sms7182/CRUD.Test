using Car.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.BaseCommandQuery
{
    public abstract class BaseCommand<T, U> : IRequest<U> where T : RequestDto where U : ResponseDto
    {
        public string? UserId { get; set; }
        public T RequestDto { get; set; }
    }
}
