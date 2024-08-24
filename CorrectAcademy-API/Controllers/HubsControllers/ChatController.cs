using Contract.HubDtos;
using CorrectAcademy_API.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Service.Abstraction.IHubServices;

namespace CorrectAcademy_API.Controllers.HubsControllers
{

    [Route("api/Hub/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<CorrectHub, IHubMethods> _hubContext;

        public ChatController(IHubContext<CorrectHub
            , IHubMethods> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendTextMessage(MessageDto modal)
        {
            try
            {
                await _hubContext.Clients.Group(modal.ClassId)
                .ReceiveTextMessage(modal.UserId, modal.Message);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDto modal)
        {
            try
            {
                await _hubContext.Clients.Group(modal.ClassId)
                .SendTextMessage(modal.UserId, modal.Message);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
    }
}
