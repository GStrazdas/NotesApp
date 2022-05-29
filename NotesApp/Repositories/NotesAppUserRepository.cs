using NotesApp.Areas.Identity.Data;
using NotesApp.Model;

namespace NotesApp.Repositories
{
    public class NotesAppUserRepository
    {
        private readonly DatabaseContext _context;

        public NotesAppUserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Note> GetUsersNotes(string userId)
        {
            try
            {
                var usr = _context.NotesAppUsers.FirstOrDefault(u => u.Id == userId);
                return usr.Notes.ToList();
            }
            catch
            {
                return new List<Note>();
            }
        }

        public List<Category> GetUsersCategories(string userId)
        {
            try
            {
                var usr = _context.NotesAppUsers.FirstOrDefault(u => u.Id == userId);
                return usr.Categories.ToList();
            }
            catch
            {
                return new List<Category>();
            }
        }
    }
}
