﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlfredoRevillaRoniAdaTest1.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error(
            [FromServices] IWebHostEnvironment webHostEnvironment,
            [FromServices] ILogger<ErrorController> logger
            )
        {
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            while (error.InnerException != null)
            {
                error = error.InnerException;
            }

            var statusCode = 500;
            if (error is ObjectNotFoundException)
            {
                statusCode = 404;
            }
            else if (
                error is ArgumentException ||
                error is ValidationException ||
                error is InvalidOperationException
                )
            {
                statusCode = 400;
            }

            logger.LogInformation($"An error is being handled by {nameof(ErrorController)}.");
            logger.LogInformation("Status code has been set to {0}.", statusCode);

            return Problem(
                title: error.Message,
                statusCode: statusCode,
#if DEBUG
                detail: error.StackTrace
#endif
                );
        }
    }
}