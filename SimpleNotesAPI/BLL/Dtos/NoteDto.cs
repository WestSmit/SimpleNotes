using System;

namespace SimpleNotes.BLL.Dtos
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
    }
}
