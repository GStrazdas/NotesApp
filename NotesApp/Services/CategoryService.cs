using NotesApp.Model;
using NotesApp.Repositories;

namespace NotesApp.Services
{
    public class CategoryService
    {
        private readonly CategoriesRepository _categoriesRepository;
        private readonly UserService _userService;

        public CategoryService(CategoriesRepository categoriesRepository, UserService userService)
        {
            _categoriesRepository = categoriesRepository;
            _userService = userService;
        }

        public List<Category> GetUserCategories()
        {
            try
            {
                var userId = _userService.GetUserID();
                return _categoriesRepository.GetCategories().Where(c=>c.NotesAppUserId == userId).ToList();
            }
            catch
            {
                return new List<Category>();
            }
        }

        public Category GetUserCategory(int id)
        {
            return GetUserCategories().FirstOrDefault(c => c.Id == id);
        }

        public Category GetUserCategory(string name)
        {
            return GetUserCategories().FirstOrDefault(c => c.Name == name);
        }

        public void CreateCategory(string name)
        {
            if (GetUserCategories().Find(c => c.Name == name) == null)
            {
                var category = new Category();
                category.Name = name;
                category.NotesAppUserId = _userService.GetUserID();
                _categoriesRepository.CreateCategory(category);
            }
        }

        public void DeleteUserCategory(int id)
        {
            var category = GetUserCategory(id);
            if(category != null)
            {
                _categoriesRepository.DeleteCategory(category);
            }
        }

        public void DeleteUserCategory(string name)
        {
            var category = GetUserCategory(name);
            if (category != null)
            {
                _categoriesRepository.DeleteCategory(category);
            }
        }

        public void UpdateUserCategory(Category category)
        {
            var dbCategory = GetUserCategory(category.Id);
            if (dbCategory != null)
            {
                dbCategory.Name = category.Name;
                _categoriesRepository.UpdateCategory(dbCategory);
            }
        }
    }
}
