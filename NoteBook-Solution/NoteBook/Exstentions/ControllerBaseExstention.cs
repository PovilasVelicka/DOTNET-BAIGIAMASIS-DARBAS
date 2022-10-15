using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Controllers.AuthController;

namespace NoteBook.Exstentions
{
    internal static class ControllerBaseExeption
    {
        public static ObjectResult GetActionResult (this ControllerBase controller, IServiceResponseDto serverResponseDto, object? responseValue)
        {

            var objectResult = new ObjectResult(new Payload
            {
                Success = serverResponseDto.IsSuccess,
                Message = serverResponseDto.Message,
                Data = responseValue,
            });
            objectResult.StatusCode = serverResponseDto.StatuCode;
            return objectResult;
        }
    }

    internal class Payload
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
