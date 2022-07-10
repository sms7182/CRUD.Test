using Car.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.BaseCommandQuery
{
    public abstract class BaseQuery<T,U> :IRequest<U> where T: RequestDto where U:ResponseDto
    {
        public T RequestDto { get; set; }
        public string? UserId { get; set; }
    }
}
