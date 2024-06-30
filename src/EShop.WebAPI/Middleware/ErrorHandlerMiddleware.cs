using System.Net;
using System.Text.Json;
using EShop.BLL.Exceptions;
using EShop.WebAPI.Constants;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            statusCode = exception switch
            {
                LoginFailedException e => e.Code,
                RegistrationFailedException e => e.Code,
                NotFoundException e => e.Code,
                ValidationException e => HttpStatusCode.BadRequest,
                _ => statusCode
            };

            context.Response.ContentType = ContentTypes.ApplicationJson;
            context.Response.StatusCode = (int)statusCode;
            
            var errors = string.Empty;

            if (exception is ValidationException validationException)
            {
                var errorMessages = validationException.Errors
                    .Select(e => e.ErrorMessage)
                    .ToArray();
                errors = string.Join('\n', errorMessages);
            }
            
            if (exception is RegistrationFailedException registrationFailedException)
            {
                var errorMessages = (registrationFailedException.Errors ?? Array.Empty<IdentityError>())
                    .Select(e => e.Description)
                    .ToArray();
                errors = string.Join('\n', errorMessages);
            }

            var errorResponse = new
            {
                Timestamp = DateTime.Now,
                StatusCode = statusCode,
                Error = string.IsNullOrEmpty(errors) ? "Something went wrong." : errors
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}