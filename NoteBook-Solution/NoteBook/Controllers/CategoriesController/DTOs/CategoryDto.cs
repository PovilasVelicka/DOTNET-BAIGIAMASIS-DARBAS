using NoteBook.Entity.Models;

namespace NoteBook.Controllers.CategoriesController.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public CategoryDto ( ) { }

        public CategoryDto (Category category )
        {
            Id = category.Id;
            CategoryName = category.CategoryName;
        }
    }
}
