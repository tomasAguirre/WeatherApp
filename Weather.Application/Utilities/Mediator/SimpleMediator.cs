using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Exceptions;

namespace Weather.Application.Utilities.Mediator
{
    public class SimpleMediator : IMediator
    {
        private readonly IServiceProvider serviceProvider;

        public SimpleMediator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            var UseCaseType = typeof(IRequestHandler<,>)
                .MakeGenericType(request.GetType(), typeof(TResponse));

            var UseCase = this.serviceProvider.GetService(UseCaseType);

            if (UseCase == null) 
            {
                throw new MediatorException($"No handler found for {request.GetType().Name}");
            }
            var method = UseCaseType.GetMethod("Handle");

            return await (Task<TResponse>)method.Invoke(UseCase, new object[] { request });
        }
    }
}
