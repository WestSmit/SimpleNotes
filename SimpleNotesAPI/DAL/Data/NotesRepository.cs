using Microsoft.EntityFrameworkCore;
using SimpleNotes.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNotes.DAL.Data
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
            await _context.Notes.AddAsync(note);
        }

        public async Task DeleteNote(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
            _context.Notes.Remove(note);
        }

        public async Task<Note> GetNote(int id)
        {
            return await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);            
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateNote(int id, Note newNote)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            note.Text = newNote.Text;
            note.Title = newNote.Title;
            note.UserName = newNote.UserName;
        }
    }
}
