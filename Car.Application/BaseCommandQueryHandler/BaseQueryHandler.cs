using Car.Application.BaseCommandQuery;
using Car.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.BaseCommandQueryHandler
{
    public abstract class BaseQueryHandler<H, T, U> : IRequestHandler<H, U> where H : BaseQuery<T, U>, new() where T : RequestDto where U : ResponseDto
    {
        public async Task<U> Handle(H request, CancellationToken cancellationToken)
        {
            return await Handler(request, cancellationToken);
        }

        public abstract Task<U> Handler(H request, CancellationToken cancellationToken = default);
    }
}
