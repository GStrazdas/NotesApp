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
        private readonly UserService _userService;
        private readonly NotesAppUserRepository _userRepository;

        public List<Note> Notes { get; set; }
        public List<Note> UserNotes { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            NotesRepository repository,
            NotesAppUserRepository userRepository,
            UserService userService)
        {
            _logger = logger;
            _repository = repository;
            _userRepository = userRepository;
            _userService = userService;
        }

        public void OnGet()
        {
            var usr = _userService.GetUserId();
            //Notes = _repository.GetNotes();
            Notes = _repository.GetNotes().Where(n=>n.NotesAppUserId == usr).ToList();
            //UserNotes = _userRepository.GetUsersNotes(usr).ToList();
        }
    }
}