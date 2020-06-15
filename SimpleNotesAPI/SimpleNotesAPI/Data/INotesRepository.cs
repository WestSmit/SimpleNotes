using SimpleNotes.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNotes.API.Data
{
    public interface INotesRepository
    {
        IEnumerable<Note> GetNotes();
        Task<Note> GetNote(int id);
        Task AddNote(Note note);
        Task UpdateNote(int id, Note note);
        Task DeleteNote(int id);
        Task<bool> SaveAll();

    }
}
