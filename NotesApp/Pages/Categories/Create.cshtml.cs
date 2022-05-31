using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;
using NotesApp.Services;

namespace NotesApp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly CategoryService _categoryService;
        [BindProperty]
        public string CategoryName { get; set; }

        public CreateModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _categoryService.CreateCategory(CategoryName);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
