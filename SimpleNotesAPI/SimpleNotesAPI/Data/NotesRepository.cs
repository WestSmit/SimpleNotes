using Microsoft.EntityFrameworkCore;
using SimpleNotes.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNotes.API.Data
{
    public class NotesRepository : INotesRepository
    {
        private readonly DataContext _context;

        public NotesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddNote(Note note)
        {
            if (note == null)
            {
                throw new Exception("Note is null");
            }

            await _context.Notes.AddAsync(note);
        }

        public async Task DeleteNote(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            if(note == null)
            {
                throw new Exception("Note not found");
            }

            _context.Notes.Remove(note);
        }

        public async Task<Note> GetNote(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            if (note == null)
            {
                throw new Exception("Note not found");
            }

            return note;
        }

        public IEnumerable<Note> GetNotes()
        {
            return _context.Notes;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateNote(int id, Note newNote)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            if (note == null)
            {
                throw new Exception("Note not found");
            }

            note.Text = newNote.Text;
            note.Title = newNote.Title;
            note.UserName = newNote.UserName;
        }
    }
}
