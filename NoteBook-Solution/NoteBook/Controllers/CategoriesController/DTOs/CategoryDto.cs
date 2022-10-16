using NoteBook.Entity.Models;

namespace NoteBook.Controllers.CategoriesController.DTOs
{
    public class CategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }


        public CategoryDto ( ) { }

        public CategoryDto (Category? category)
        {
            if (category == null) return;
            Id = category.Id;
            CategoryName = category.CategoryName;
        }
    }
}
