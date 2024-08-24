using Contract.AuthDtos;
using Domain.Exceptions;
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
        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> Confirm(string email)
        {
            try
            {
                string otp = _service.GenerateOtp();
                await _service.EmailService.SendConfirmationEmail(email, otp);
                return Ok(otp);
            }
            catch (Exception ex)
            {
                return StatusCode(505, ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegestrationDto model)
        {
            try
            {
                await _service.AuthService.RegesterAsync(model);
                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (SettingsNotFoundException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (IdentityException ex)
            {
                return Problem(ex.Message);
            }
            catch (PropertyException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(LoginDto model)
        {
            try
            {
                var result = await _service.AuthService.LogInAsync(model);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (SettingsNotFoundException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (IdentityException ex)
            {
                return Problem(ex.Message);
            }
            catch (PropertyException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("ExternalAuthentication")]
        public async Task<IActionResult> ExternalAsync(GoogleAuthDto model)
        {
            try
            {
                var result = await _service.AuthService.AuthinticationWithGoogle(model);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (SettingsNotFoundException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (IdentityException ex)
            {
                return Problem(ex.Message);
            }
            catch (PropertyException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            try
            {
                var tokenOtp = await _service.AuthService.RestPassword(email);

                await _service.EmailService.SendResetPassword(email, tokenOtp.Otp);

                return Ok(tokenOtp.Token);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (SettingsNotFoundException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (IdentityException ex)
            {
                return Problem(ex.Message);
            }
            catch (PropertyException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ForgetPasswordDto passwordDto)
        {
            try
            {
                await _service.AuthService.RestPassword(passwordDto);

                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (NotAllowedException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (SettingsNotFoundException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (IdentityException ex)
            {
                return Problem(ex.Message);
            }
            catch (PropertyException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
