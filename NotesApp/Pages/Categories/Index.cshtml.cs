using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;
using NotesApp.Repositories;
using NotesApp.Services;

namespace NotesApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly CategoryService _categoryService;
        private readonly CategoriesRepository _categoriesRepository;
        public List<Category> Categories { get; set; }

        public IndexModel(CategoryService categoryService, CategoriesRepository categoriesRepository)
        {
            _categoryService = categoryService;
            _categoriesRepository = categoriesRepository;
        }

        public void OnGet()
        {
            Categories = _categoryService.GetUserCategories();
        }

        public IActionResult OnPostDelete(int id)
        {
            var category = _categoryService.GetUserCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            _categoriesRepository.DeleteCategory(category);
            return RedirectToPage("Index");
        }
    }
}
