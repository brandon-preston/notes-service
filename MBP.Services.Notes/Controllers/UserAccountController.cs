using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MBP.Services.Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly BLL.UserAccountDomain m_domain;

        public UserAccountController()
        {
            m_domain = new BLL.UserAccountDomain();
        }

        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("UserAccountCreate")]
        public async Task<IActionResult> UserAccountCreate(DataTransferObjects.User user)
        {
            return Ok(await m_domain.UserAccountCreate(user));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(DataTransferObjects.User user)
        {
            return Ok(await m_domain.Login(user));
        }
    }
}