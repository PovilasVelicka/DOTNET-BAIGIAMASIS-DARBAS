using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.Attributes;
using NoteBook.Controllers.CategoriesController.DTOs;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;
using NoteBook.Exstentions;

namespace NoteBook.Controllers.CategoriesController
{
    [Authorize]
    [Route("notebook/categories")]
    [ApiController]
    [AuthorizeRoles(Role.StandartUser, Role.PeopleAdmin)]
    public class CategoriesController : ControllerBase
    {
        private readonly INotesService _service;
        public CategoriesController (INotesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ( )
        {
            var serviceResult = await _service.GetCategoriesAsync(this.GetUserGuid( ));
            return this.GetActionResult(serviceResult, serviceResult.Object?.Select(c => new CategoryDto(c)) ?? default);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory (CreateCategoryDto dto)
        {
            var serviceResult = await _service.CreateCategoryAsync(this.GetUserGuid( ),dto.CategoryName);               
            return this.GetActionResult(serviceResult, new CategoryDto(serviceResult.Object!));
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCategory (int id, CreateCategoryDto dto)
        {
            var serviceResult = await _service.UpdateCategoryAsync(
                this.GetUserGuid( ),
                categoryId: id,
                categoryName: dto.CategoryName) ;
               

            return this.GetActionResult(serviceResult, new CategoryDto(serviceResult.Object!));
        }

        [HttpPatch("delete/{id}")]
        public async Task<IActionResult> DeleteCategory (int id)
        {
            var serviceResult = await _service.DeleteCategoryAsync(
                this.GetUserGuid( ),
                categoryId: id);

            return this.GetActionResult(serviceResult, new CategoryDto(serviceResult.Object!));
        }
    }
}
