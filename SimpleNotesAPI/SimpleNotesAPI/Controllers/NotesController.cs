using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleNotes.API.Data;
using SimpleNotes.API.Models;


namespace SimpleNotes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepository _repo;
        public NotesController(INotesRepository repo)
        {
            _repo = repo;
        }
        // GET: api/notes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetNotes());
        }

        // GET api/notes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var note = await _repo.GetNote(id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/notes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Note newNote)
        {
            try
            {
                newNote.Date = DateTime.Now;
                await _repo.AddNote(newNote);
                if (await _repo.SaveAll())
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Saving error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/notes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Note newNote)
        {
            try
            {
                await _repo.UpdateNote(id, newNote);
                if (await _repo.SaveAll())
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Saving error");
                }
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
                await _repo.DeleteNote(id);
                if (await _repo.SaveAll())
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Saving error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
