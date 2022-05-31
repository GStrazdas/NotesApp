using NotesApp.Areas.Identity.Data;
using NotesApp.Model;
using NotesApp.Repositories;
using System.Security.Claims;

namespace NotesApp.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly NotesAppUserRepository _userRepository;

        public UserService(IHttpContextAccessor contextAccessor, NotesAppUserRepository userRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }
        public string GetUserName()
        {
            var userName = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            return userName;
        }

        public string GetUserID()
        {
            var userId = _userRepository.GetUserIdByName(GetUserName());
            return userId;
        }
    }
}
