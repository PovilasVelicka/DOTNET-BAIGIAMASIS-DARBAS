using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.DTOs;
using System.Security.Claims;

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

        public static Guid GetUserGuid (this ControllerBase controller)
        {
            var userIdClaim = controller.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null) { return Guid.Empty; }

            Guid.TryParse(userIdClaim.Value, out Guid UserId);
            return UserId;
        }
    }

    internal class Payload
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
