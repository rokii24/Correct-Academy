using Contract.AuthDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction.IExternalServices;

namespace CorrectAcademy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthintecationController : ControllerBase
    {
        private readonly IExternalService _service;
        public AuthintecationController(IExternalService service)
        {
            _service = service;
        }

        [HttpPost("ExternalAuthentication")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> ExternalAsync(GoogleAuthDto model)
        {
            try
            {
                var result = await _service.AuthService.AuthenticationWithGoogle(model);
                return Ok(new { UserID = result.Item1, Token = result.Item2, Name = result.Item3 });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
