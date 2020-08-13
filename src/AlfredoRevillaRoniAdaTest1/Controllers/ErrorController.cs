using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AlfredoRevillaRoniAdaTest1.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            while (error.InnerException != null)
            {
                error = error.InnerException;
            }

            return Problem(
                title: error.Message,
#if DEBUG
                detail: error.StackTrace
#endif
                );

        }
    }
}