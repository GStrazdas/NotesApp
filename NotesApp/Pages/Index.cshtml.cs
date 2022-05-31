using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;
using NotesApp.Repositories;
using NotesApp.Services;
using System.Security.Claims;

namespace NotesApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NotesRepository _repository;
        private readonly NotesAppUserRepository _userRepository;
        private readonly UserService _userService;
        private readonly NoteService _noteService;
        
        public List<Note> Notes { get; set; } = new List<Note>();
        [BindProperty]
        public Note Note { get; set; } = new Note();
        public string UserId { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            NotesRepository repository,
            NotesAppUserRepository userRepository,
            UserService userService,
            NoteService noteService)
        {
            _logger = logger;
            _repository = repository;
            _userRepository = userRepository;
            _userService = userService;
            _noteService = noteService;
        }

        public void OnGet()
        {
            UserId = _userService.GetUserID();
            Notes = _repository.GetNotes().Where(n => n.NotesAppUserId == UserId).ToList();
            Note.NotesAppUserId = UserId;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _noteService.CreateNote(Note);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}