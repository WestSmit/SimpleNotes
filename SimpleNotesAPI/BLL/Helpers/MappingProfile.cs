using AutoMapper;
using SimpleNotes.BLL.Dtos;
using SimpleNotes.DAL.Models;

namespace SimpleNotes.BLL.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Note, NoteDto>().ReverseMap();
        }
    }
}
