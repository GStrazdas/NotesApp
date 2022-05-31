using Microsoft.EntityFrameworkCore;
using NotesApp.Areas.Identity.Data;
using NotesApp.Model;

namespace NotesApp.Repositories
{
    public class CategoriesRepository
    {
        private readonly DatabaseContext _context;

        public CategoriesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name == name);
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
