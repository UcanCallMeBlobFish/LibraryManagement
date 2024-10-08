﻿using System.Net;
using System.Text.Json;

namespace RestAPI.Middleware
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {

            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "exception occur");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            ResponseModel exModel = new ResponseModel();

            switch (exception)
            {
                case ArgumentException ex:
                    exModel.responseCode = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    exModel.responseMessage = $"Invalid argument: {ex.Message}";
                    break;
                case KeyNotFoundException ex:
                    exModel.responseCode = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exModel.responseMessage = $"Resource not found: {ex.Message}";
                    break;
                default:
                    exModel.responseCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    exModel.responseMessage = "Internal Server Error, Please retry after some time.";
                    break;
            }


            var exResult = JsonSerializer.Serialize(exModel);
            await context.Response.WriteAsync(exResult);
        }
    }
}
