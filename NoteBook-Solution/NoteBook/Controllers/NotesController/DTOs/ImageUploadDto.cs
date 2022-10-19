using NoteBook.Controllers.Validation;

namespace NoteBook.Controllers.NotesController.DTOs
{

        public class ImageUploadDto
        {
            [MaxFileSize(256 * 1024 )]
            [AllowedExtensions(new[ ] { ".png", ".jpg", ".jpeg" })]
            public IFormFile Image { get; set; } = null!;

        }
  
}
