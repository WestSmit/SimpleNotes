using SimpleNotes.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNotes.DAL.Data
{
    public interface INotesRepository
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<Note> GetNote(int id);
        Task AddNote(Note note);
        Task UpdateNote(int id, Note note);
        Task DeleteNote(int id);
        Task<bool> SaveAll();

    }
}
