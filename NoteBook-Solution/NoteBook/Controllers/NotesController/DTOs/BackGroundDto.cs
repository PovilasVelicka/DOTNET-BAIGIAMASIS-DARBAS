using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace NoteBook.Controllers.NotesController.DTOs
{
    public class BgImageDto
    {
        public FileContentResult Content { get;  } = null!;
        public BgImageDto ( byte[ ] imageBytes, string contentType )
        {
            Content = new FileContentResult(imageBytes, contentType);         
        }
       
    }
}
