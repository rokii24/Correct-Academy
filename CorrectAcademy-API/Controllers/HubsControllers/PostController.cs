using Contract.HubDtos;
using CorrectAcademy_API.Hubs;
using Domain.Enums;
using Domain.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Abstraction.IExternalServices;
using Service.Abstraction.IHubServices;

namespace CorrectAcademy_API.Controllers.HubsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IHubContext<CorrectHub, IHubMethods> _hubContext;
        private readonly IExternalService _externalService;

        public PostController(IHubContext<CorrectHub, IHubMethods> hubContext, IExternalService externalService)
        {
            _hubContext=hubContext;
            _externalService=externalService;
        }

        [HttpPost("SendText")]
        public async Task<IActionResult> SendTextComment(CommentDto modal)
        {
            try
            {
                // Add comment into DB
                // 
                await _hubContext.Clients.Group(modal.PostId)
                .ReceiveComment(modal.UserId, modal.Message, MessageType.Text);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendTextReply")]
        public async Task<IActionResult> SendTextCommentReply(CommentReplyDto modal)
        {
            try
            {
                // Add comment reply into DB
                // 
                await _hubContext.Clients.Group(modal.CommentId)
                .ReceiveCommentReply(modal.CommentId, modal.Message , MessageType.Text);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }

        [HttpPost("SendImage")]
        public async Task<IActionResult> SendImageComment(CommentDto modal)
        {
            try
            {
                // Add comment into DB
                // 
                var path = Path.Combine(modal.AcademyId,modal.PostId  ,"CommentId" );
                await _externalService.FileService.SaveImage(path,modal.Message);
                await _hubContext.Clients.Group(modal.PostId)
                .ReceiveComment(modal.UserId, path, MessageType.Image);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendImageReply")]
        public async Task<IActionResult> SendImageCommentReply(CommentReplyDto modal)
        {
            try
            {
                // Add comment reply into DB
                // 
                var path = Path.Combine(modal.AcademyId, modal.PostId ,"CommentId");
                await _externalService.FileService.SaveImage(path, modal.Message);
                await _hubContext.Clients.Group(modal.CommentId)
                .ReceiveCommentReply(modal.UserId, modal.CommentId, path , MessageType.Image);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendVideo")]
        public async Task<IActionResult> SendVideoComment(CommentDto modal)
        {
            try
            {
                // Add comment into DB
                // 
                var path = Path.Combine(modal.AcademyId, modal.PostId, "CommentId");
                await _externalService.FileService.SaveVideo(path, modal.Message);
                await _hubContext.Clients.Group(modal.PostId)
                .ReceiveComment(modal.UserId, path, MessageType.Video);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }

        [HttpPost("SendVideoReply")]
        public async Task<IActionResult> SendVideoReply(CommentReplyDto modal)
        {
            try
            {
                // Add comment reply into DB
                // 
                var path = Path.Combine(modal.AcademyId, modal.PostId, "CommentId");
                await _externalService.FileService.SaveVideo(path, modal.Message);
                await _hubContext.Clients.Group(modal.CommentId)
                .ReceiveCommentReply(modal.UserId, modal.CommentId, path, MessageType.Video);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendVoice")]
        public async Task<IActionResult> SendVoiceComment(CommentDto modal)
        {
            try
            {
                // Add comment into DB
                // 
                var path = Path.Combine(modal.AcademyId, modal.PostId, "CommentId");
                await _externalService.FileService.SaveVoice(path, modal.Message);
                await _hubContext.Clients.Group(modal.PostId)
                .ReceiveComment(modal.UserId, path , MessageType.Voice);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendVoiceReply")]
        public async Task<IActionResult> SendVoiceReply(CommentReplyDto modal)
        {
            try
            {
                // Add comment reply into DB
                // 
                var path = Path.Combine(modal.AcademyId, modal.PostId, "CommentId");
                await _externalService.FileService.SaveVoice(path, modal.Message);
                await _hubContext.Clients.Group(modal.CommentId)
                .ReceiveCommentReply(modal.UserId, modal.CommentId, path, MessageType.Voice);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendPdf")]
        public async Task<IActionResult> SendPdfComment(CommentDto modal)
        {
            try
            {
                // Add comment into DB
                // 
                var path = Path.Combine(modal.AcademyId, modal.PostId, "CommentId");
                await _externalService.FileService.SavePdf(path, modal.Message);
                await _hubContext.Clients.Group(modal.PostId)
                .ReceiveComment(modal.UserId, path, MessageType.PDF);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendPdfReply")]
        public async Task<IActionResult> SendPdfReply(CommentReplyDto modal)
        {
            try
            {
                // Add comment reply into DB
                // 
                var path = Path.Combine(modal.AcademyId, modal.PostId, "CommentId");
                await _externalService.FileService.SavePdf(path, modal.Message);
                await _hubContext.Clients.Group(modal.CommentId)
                .ReceiveCommentReply(modal.UserId ,modal.CommentId, path, MessageType.PDF);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }


    }
}
