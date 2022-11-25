using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Roulette.Models;

namespace Roulette.Middleware
{
    public class ProcessFailureResponseHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private IMediator _mediator;

        public ProcessFailureResponseHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IMediator mediator)
        {
            _mediator = mediator;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex);
            }
        }

        private async Task HandleExceptionAsync(Exception exception)
        {
            await _mediator.Send(new CreateExceptionCommand { StackTrace = exception.StackTrace, ErrorMessage = exception.Message });
        }
    }
}
