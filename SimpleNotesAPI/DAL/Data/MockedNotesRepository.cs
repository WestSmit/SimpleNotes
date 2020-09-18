using SimpleNotes.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNotes.DAL.Data
{
    public class MockedNotesRepository : INotesRepository
    {
        private List<Note> notes;

        public MockedNotesRepository()
        {
            notes = new List<Note>();

            notes.AddRange(
                new Note[] {
                    new Note() { Date = DateTime.Now, Text = "First initial Note", Id=1},
                    new Note() { Date = DateTime.Now, Text = "Second initial Note", Id=2 },
                    new Note() { Date = DateTime.Now, Text = "Third initial Note", Id=3 }
                }
           );
        }
        public Task AddNote(Note note)
        {
            notes.Add(note);
            return Task.CompletedTask;
        }

        public Task DeleteNote(int id)
        {
            var note = notes.FirstOrDefault(n => n.Id == id);
            notes.Remove(note);
            return Task.CompletedTask;
        }

        public Task<Note> GetNote(int id)
        {
            var note = notes.FirstOrDefault(n => n.Id == id);
            return Task.FromResult<Note>(note);
        }

        public Task<IEnumerable<Note>> GetNotes()
        {
            return Task.FromResult<IEnumerable<Note>>(notes);
        }

        public Task<bool> SaveAll()
        {
            return Task.FromResult(true);
        }

        public Task UpdateNote(int id, Note newNote)
        {
            var index = notes.FindIndex(n => n.Id == id);
            notes[index] = newNote;
            return Task.CompletedTask;
        }
    }
}
