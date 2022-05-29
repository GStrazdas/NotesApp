using Microsoft.EntityFrameworkCore;
using NotesApp.Areas.Identity.Data;
using NotesApp.Model;

namespace NotesApp.Repositories
{
    public class NotesRepository
    {
        private readonly DatabaseContext _context;

        public NotesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Note> GetNotes()
        {
            try
            {
                return _context.Notes.ToList();
            }
            catch
            {
                return new List<Note>();
            }
        }

        public Note GetNoteByTitle(string title) => _context.Notes.FirstOrDefault(n => n.Title == title);

        public Note GetNoteById(int id) => _context.Notes.FirstOrDefault(n => n.Id == id);

        public void Createnote(Note note)
        {
            if(note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            if(GetNoteByTitle(note.Title) == null)
            {
                _context.Notes.Add(note);
                _context.SaveChanges();
            }
        }

        public void DeleteNote(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if(note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges(true);
            }
        }

        public void UpdateNote(Note note)
        {
            _context.Entry(note).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
