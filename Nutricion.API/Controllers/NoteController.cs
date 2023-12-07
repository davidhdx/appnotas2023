using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutricion.API.Data;
using Nutricion.API.Models;

namespace Nutricion.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public NoteController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost("register")]

        public async Task<ActionResult<int>> save(Note note)
        {
            var newNote = note;
            context.Add(newNote);
            await context.SaveChangesAsync();
            if (newNote.ID > 0)
                return newNote.ID;
            else
                return BadRequest();
        }

        [HttpGet("list")]

        public async Task<ActionResult<List<Note>>> Registros()
        {
            var lista = new List<Note>();
            lista = await context.RegisteredNotes.ToListAsync();
            if (lista.Count > 0)
                return lista;
            else
                return NoContent();
        }


        [HttpGet("only/{id}")]

        public async Task<ActionResult<Note>> OnlyNote(int id)
        {
            var solo = new Note();
            solo = await context.RegisteredNotes.Where(i => i.ID == id).FirstOrDefaultAsync();

            if (solo != null)
                return solo;
            else
                return NoContent();
        }
    }
}

