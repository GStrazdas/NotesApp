using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;
using NotesApp.Services;

namespace NotesApp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly CategoryService _categoryService;
        [BindProperty]
        public Category Category { get; set; }

        public EditModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void OnGet(int id)
        {
            Category = _categoryService.GetUserCategory(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateUserCategory(Category);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
