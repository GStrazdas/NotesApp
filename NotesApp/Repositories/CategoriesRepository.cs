using NotesApp.Areas.Identity.Data;

namespace NotesApp.Repositories
{
    public class CategoriesRepository
    {
        private readonly DatabaseContext _context;

        public CategoriesRepository(DatabaseContext context)
        {
            _context = context;
        }


    }
}
