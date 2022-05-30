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
        
        public List<Note> Notes { get; set; } = new List<Note>();

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
            var userId = _userService.GetUserID();
            Notes = _repository.GetNotes().Where(n => n.NotesAppUserId == userId).ToList();
            //UserNotes = _userRepository.GetUsersNotes(usr).ToList();
        }
    }
}