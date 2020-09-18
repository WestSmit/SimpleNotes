using SimpleNotes.BLL.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNotes.BLL.Services
{
    public interface INotesService
    {
        Task AddNote(NoteDto noteDto);
        Task<IEnumerable<NoteDto>> GetNotes();
        Task<NoteDto> GetNote(int id);
        Task UpdateNote(int id, NoteDto note);
        Task DeleteNote(int id);
    }
}
