using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MBP.Services.Notes.Controllers
{
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        private readonly BLL.ExceptionDomain m_domain;

        public ExceptionController()
        {
            m_domain = new BLL.ExceptionDomain();
        }

        [Route("ExceptionCreate")]
        public async Task<IActionResult> ExceptionCreate()
        {
            IExceptionHandlerFeature feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception exception = feature?.Error;

            await m_domain.ExceptionCreate(exception);

            return Problem();
        }
    }
}
