using NotesApp.Model;
using NotesApp.Repositories;

namespace NotesApp.Services
{
    public class NoteService
    {
        private readonly NotesRepository _notesRepository;
        private readonly UserService _userService;

        public NoteService(NotesRepository notesRepository, UserService userService)
        {
            _notesRepository = notesRepository;
            _userService = userService;
        }

        public void CreateNote(Note note)
        {
            var newNote = new Note();
            newNote.Title = note.Title;
            newNote.Content = note.Content;
            newNote.NotesAppUserId = note.NotesAppUserId;
            _notesRepository.CreateNote(newNote);
        }
    }
}
