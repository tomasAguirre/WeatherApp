﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Application.Utilities.Mediator
{
    public interface IRequestHandler<TRequest, TResponse>
        where TRequest: IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
