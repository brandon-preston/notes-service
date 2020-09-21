using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MBP.Services.Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly BLL.NotesDomain m_domain;

        public NoteController()
        {
            m_domain = new BLL.NotesDomain();
        }

        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("NoteCreate")]
        public async Task<IActionResult> NoteCreate(DataTransferObjects.Note note)
        {
            return Ok(await m_domain.NoteCreate(note));
        }

        [HttpGet("NoteSelectAll/{id}")]
        public IActionResult NoteSelectAll(int id)
        {
            return Ok(m_domain.NoteSelectAll(id));
        }

        [HttpGet("NoteSelect/{id}")]
        public async Task<IActionResult> NoteSelect(int id)
        {
            return Ok(await m_domain.NoteSelect(id));
        }

        [HttpPut("NoteUpdate")]
        public async Task<IActionResult> NoteUpdate(DataTransferObjects.Note note)
        {
            await m_domain.NoteUpdate(note);

            return Ok();
        }

        [HttpDelete("NoteDelete/{id}")]
        public async Task<IActionResult> NoteDelete(int id)
        {
            await m_domain.NoteDelete(id);

            return Ok();
        }
    }
}