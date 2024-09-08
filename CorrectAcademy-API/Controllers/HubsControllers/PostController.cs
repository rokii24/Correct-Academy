using Contract.AddDtos;
using Contract.HubDtos;
using CorrectAcademy_API.Hubs;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Service.Abstraction.IDataServices;
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
        private readonly IAdminDataService _adminDataService;

        public PostController(IHubContext<CorrectHub, IHubMethods> hubContext, IExternalService externalService, IAdminDataService adminDataService)
        {
            _hubContext=hubContext;
            _externalService=externalService;
            _adminDataService=adminDataService;
        }

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost(AddPostDto modal)
        {
            try
            {
               var postid =  await _adminDataService.PostService.Add(modal);
                var Post = await _adminDataService.PostService.Get(postid);
                await _hubContext.Clients.Group(modal.AcademyId)
                .ReceivePost(modal.UserId, Post );
                return Ok(Post);
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
       
        [HttpPost("SendText")]
        public async Task<IActionResult> SendTextComment(CommentDto modal)
        {
            try
            {
                var CommentId = await _adminDataService.PostService.Add(modal, "Text");

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
                var path = await _adminDataService.PostService.Add(modal, "Text");

                await _hubContext.Clients.Group(modal.CommentId)
                .ReceiveCommentReply(modal.UserId ,modal.CommentId, modal.Message , MessageType.Text);
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
                var path = await _adminDataService.PostService.Add(modal, "Image");
                //var path = Path.Combine(modal.AcademyId,modal.PostId  ,CommentId.ToString());
                //await _externalService.FileService.SaveImage(path,modal.Message);
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
                var path = await _adminDataService.PostService.Add(modal, "Image");

                //var path = Path.Combine(modal.AcademyId, modal.PostId, CommentId.ToString());
                //await _externalService.FileService.SaveImage(path, modal.Message);
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
                var path = await _adminDataService.PostService.Add(modal, "Video");

                //var path = Path.Combine(modal.AcademyId, modal.PostId, CommentId.ToString());
                //await _externalService.FileService.SaveVideo(path, modal.Message);
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
                var path = await _adminDataService.PostService.Add(modal, "Video");

                //var path = Path.Combine(modal.AcademyId, modal.PostId, CommentId.ToString());
                //await _externalService.FileService.SaveVideo(path, modal.Message);
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
                var path = await _adminDataService.PostService.Add(modal, "Voice");

                //var path = Path.Combine(modal.AcademyId, modal.PostId, CommentId.ToString());
                //await _externalService.FileService.SaveVoice(path, modal.Message);
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
                var path = await _adminDataService.PostService.Add(modal, "Voice");

                //var path = Path.Combine(modal.AcademyId, modal.PostId, CommentId.ToString());
                //await _externalService.FileService.SaveVoice(path, modal.Message);
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
                var path = await _adminDataService.PostService.Add(modal, "PDF");

                //var path = Path.Combine(modal.AcademyId, modal.PostId, CommentId.ToString());
                //await _externalService.FileService.SavePdf(path, modal.Message);
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
                var path = await _adminDataService.PostService.Add(modal, "PDF");

                //var path = Path.Combine(modal.AcademyId, modal.PostId, CommentId.ToString());
                //await _externalService.FileService.SavePdf(path, modal.Message);
                await _hubContext.Clients.Group(modal.CommentId)
                .ReceiveCommentReply(modal.UserId ,modal.CommentId, path, MessageType.PDF);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost(UpdatePostDto modal)
        {
            try
            {
                await _adminDataService.PostService.UpdatePost(modal);
                //var Post = await _adminDataService.PostService.Get(postid);
                //await _hubContext.Clients.Group(modal.AcademyId)
                //.ReceivePost(modal.UserId, Post);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPut("UpdatePostImages")]
        public async Task<IActionResult> UpdatePostImages(UpdatePostImagesDto modal)
        {
            try
            {
                await _adminDataService.PostService.UpdatePost(modal);
                //var Post = await _adminDataService.PostService.Get(postid);
                //await _hubContext.Clients.Group(modal.AcademyId)
                //.ReceivePost(modal.UserId, Post);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateComment(UpdateComment modal)
        {
            try
            {
                await _adminDataService.PostService.UpdateComment(modal);
                //var Post = await _adminDataService.PostService.Get(postid);
                //await _hubContext.Clients.Group(modal.AcademyId)
                //.ReceivePost(modal.UserId, Post);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost([FromBody]Guid PostId)
        {
            try
            {
                await _adminDataService.PostService.DeletePost(PostId);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteComment([FromBody]Guid CommentId)
        {
            try
            {
                await _adminDataService.PostService.DeleteComment(CommentId);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpGet("GetallCommentOfPost")]
        public async Task<IActionResult> GetallComment([FromBody] Guid PostId)
        {
            try
            {
                await _adminDataService.PostService.GetAllCommentOfPost(PostId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }

    }
}
