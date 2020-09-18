using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleNotes.BLL.Dtos;
using SimpleNotes.BLL.Services;

namespace SimpleNotes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notes;
        public NotesController(INotesService notes)
        {
            _notes = notes;
        }

        // GET: api/notes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var notes = await _notes.GetNotes();
                return Ok(notes);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET api/notes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var note = await _notes.GetNote(id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/notes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NoteDto newNote)
        {
            try
            {
                await _notes.AddNote(newNote);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/notes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NoteDto newNote)
        {
            try
            {
                await _notes.UpdateNote(id, newNote);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/notes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _notes.DeleteNote(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
