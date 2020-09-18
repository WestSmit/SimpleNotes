using AutoMapper;
using SimpleNotes.BLL.Dtos;
using SimpleNotes.DAL.Data;
using SimpleNotes.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNotes.BLL.Services
{
    public class NotesService: INotesService
    {
        private readonly INotesRepository _repo;
        private readonly IMapper _mapper;
        public NotesService(INotesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddNote(NoteDto noteDto)
        {
            if (noteDto != null)
            {
                if (string.IsNullOrEmpty(noteDto.Text))
                {
                    throw new Exception("Text is empty");
                }

                var newNote = _mapper.Map<Note>(noteDto);

                newNote.Date = DateTime.Now;

                await _repo.AddNote(newNote);
                if (!await _repo.SaveAll())
                {
                    throw new Exception("Saving error");
                }
            }
        }

        public async Task DeleteNote(int id)
        {
            await _repo.DeleteNote(id);
            if(!await _repo.SaveAll())
            {
                throw new Exception("Saving error");
            }
        }

        public async Task<NoteDto> GetNote(int id)
        {
            var note = await _repo.GetNote(id);

            if (note != null)
            {
                return _mapper.Map<NoteDto>(note);
            }
            else
            {
                throw new Exception("Not Found");
            }
        }

        public async Task<IEnumerable<NoteDto>> GetNotes()
        {
            var notes = await _repo.GetNotes();
            return _mapper.Map<IEnumerable<NoteDto>>(notes);
        }

        public async Task UpdateNote(int id, NoteDto noteDto)
        {
            if (noteDto != null)
            {
                if (string.IsNullOrEmpty(noteDto.Text))
                {
                    throw new Exception("Text is empty");
                }

                var newNote = _mapper.Map<Note>(noteDto);
                await _repo.UpdateNote(id, newNote);

                if (!await _repo.SaveAll())
                {
                    throw new Exception("Saving error");
                }
            }
            else
            {
                throw new Exception("Note is null");
            }
            
        }


    }
}
