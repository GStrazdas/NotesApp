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

        public string GetUserIdByName(string userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
            if(user == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }
            return user.Id;
        }
    }
}
