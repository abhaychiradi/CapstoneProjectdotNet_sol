using CapstoneProjectdotNet.Interfaces;
using CapstoneProjectdotNet.Models;
using CapstoneProjectdotNet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProjectdotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private UserRepository _userRepository;
        private NoteRepository _noteRepository;

        public NoteController(UserRepository UserRepository, NoteRepository NoteRepository)
        {
            _userRepository = UserRepository;
            _noteRepository = NoteRepository;
        }

        [HttpGet("GetNotesOfUser/{UserId}")]
        public IActionResult GetNotesOfUser(int UserId)
        {
            var notes=_noteRepository.GetNotesOfUser(UserId);

            if(notes == null)
            {
                return NotFound();
            }
            return Ok(notes);
        }

       
    }
}
