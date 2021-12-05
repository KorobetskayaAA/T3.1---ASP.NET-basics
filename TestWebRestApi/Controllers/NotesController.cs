using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebRestApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        static List<Note> Notes { get; } = new List<Note>();

        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return Notes;
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public Note Get(string id)
        {
            return Notes.FirstOrDefault(n => n.Id == id);
        }

        // POST api/<NotesController>
        [HttpPost]
        public ActionResult Post([FromBody] string noteText)
        {
            var newNote = new Note(noteText);
            Notes.Add(newNote);
            return Ok(newNote);
        }

        // PUT api/<NotesController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Note note)
        {
            var noteToUpdate = Notes.FirstOrDefault(n => n.Id == note.Id);
            if (noteToUpdate == null)
            {
                return NotFound("Заметка с таким id не найдена.");
            }
            noteToUpdate.Created = note.Created;
            noteToUpdate.Text = note.Text;
            return Ok();
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var noteToDelete = Notes.FirstOrDefault(n => n.Id == id);
            if (noteToDelete == null)
            {
                return NotFound("Заметка с таким id не найдена.");
            }
            Notes.Remove(noteToDelete);
            return Ok();
        }
    }
}
