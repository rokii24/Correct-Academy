using Contract.HubDtos;
using CorrectAcademy_API.Hubs;
using Domain.Enums;
using Domain.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestSharp;
using Service.Abstraction.IExternalServices;
using Service.Abstraction.IHubServices;
using Service.ExternalServices;

namespace CorrectAcademy_API.Controllers.HubsControllers
{

    [Route("api/Hub/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<CorrectHub, IHubMethods> _hubContext;
        private readonly IExternalService _externalService;

        public ChatController(IHubContext<CorrectHub, IHubMethods> hubContext,
            IExternalService externalService)
        {
            _hubContext = hubContext;
            _externalService = externalService;
        }


        [HttpPost("SendText")]
        public async Task<IActionResult> SendTextMessage(MessageDto modal)
        {
            try
            {
                // Add Message into DB
                // 
                await _hubContext.Clients.Group(modal.ClassId)
                .ReceiveMessage(modal.UserId, modal.Message, MessageType.Text);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendImage")]
        public async Task<IActionResult> SendImageMessage(MessageDto modal)
        {
            try
            {
                // Add Message into DB
                
                string path = Path.Combine(modal.ClassId,
                    ConfigUtility.ChatFolderName, "messageId");
                await _externalService.FileService.SaveImage(path, modal.Message);
                
                await _hubContext.Clients.Group(modal.ClassId)
                .ReceiveMessage(modal.UserId, path, MessageType.Image);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendVideo")]
        public async Task<IActionResult> SendVideoMessage(MessageDto modal)
        {
            try
            {
                // Add Message into DB

                string path = Path.Combine(modal.ClassId,
                    ConfigUtility.ChatFolderName, "messageId");
                await _externalService.FileService.SaveVideo(path, modal.Message);

                await _hubContext.Clients.Group(modal.ClassId)
                .ReceiveMessage(modal.UserId, path, MessageType.Video);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }
        [HttpPost("SendPdf")]
        public async Task<IActionResult> SendPdfMessage(MessageDto messageDto)
        {
            try
            {
                // Add Message
                string path = Path.Combine(messageDto.ClassId,
                    ConfigUtility.ChatFolderName, "MessageId");
                await _externalService.FileService.SavePdf(path, messageDto.Message);
                await _hubContext.Clients.Group(messageDto.ClassId).
                    ReceiveMessage(messageDto.UserId, path, MessageType.PDF);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(501, ex.Message);
            }

        }
        [HttpPost("SendVoice")]
        public async Task<IActionResult> SendVoiceMessage(MessageDto messageDto)
        {
            try
            {
                // Add Message
                string path = Path.Combine(messageDto.ClassId,
                    ConfigUtility.ChatFolderName, "MessageId");
                await _externalService.FileService.SaveVoice(path, messageDto.Message);
                await _hubContext.Clients.Group(messageDto.ClassId).
                    ReceiveMessage(messageDto.UserId, path, MessageType.Voice);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }

        }

        [HttpPost("SendSignal")]
        public async Task<IActionResult> SendSignalMessage(MessageDto messageDto)
        {
            try
            {
               
                await _hubContext.Clients.Group(messageDto.ClassId).
                    ReceiveMessage(messageDto.UserId, messageDto.Message,
                            MessageType.Signal);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }

        }


        [HttpPost("Test")]
        public async Task<IActionResult> Test()
        {
            try
            {
                ASPSMS.SMS sms = new ASPSMS.SMS();
                sms.Userkey = "6D7EQ7K4443Z";
                sms.Password = "4dWEvatrJzBhi7QbSRFufMmG";
                sms.MessageData = "Hi";
                sms.Originator = "Correct";
                sms.AddRecipient("01064309627");
                var res = await sms.SendTextSMS();
                //sms.
                
                //var appId = "D7BEF06056291A4B375BBAC62166D9FC";
                //var options = new RestClientOptions("https://6gq91r.api.infobip.com")
                //{
                //    MaxTimeout = -1,
                //};
                //var client = new RestClient(options);
                //var request = new RestRequest("/2fa/2/applications", Method.Post);
                //request.AddHeader("Authorization", "App 7fab01a8b441a0d6220abdd6d0dfc22d-c7822494-bdce-4c0e-abb3-ed1eaa0b5515");
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Accept", "application/json");
                //var body = @"{""name"":""2fa test application"",""enabled"":true,""configuration"":{""pinAttempts"":10,""allowMultiplePinVerifications"":true,""pinTimeToLive"":""15m"",""verifyPinLimit"":""1/3s"",""sendPinPerApplicationLimit"":""100/1d"",""sendPinPerPhoneNumberLimit"":""10/1d""}}";
                //request.AddStringBody(body, DataFormat.Json);
                //RestResponse response = await client.ExecuteAsync(request);


                //var options = new RestClientOptions("https://6gq91r.api.infobip.com")
                //{
                //    MaxTimeout = -1,
                //};
                //var client = new RestClient(options);
                //var request = new RestRequest($"/2fa/2/applications/{appId}/messages", Method.Post);
                //request.AddHeader("Authorization", "App 7fab01a8b441a0d6220abdd6d0dfc22d-c7822494-bdce-4c0e-abb3-ed1eaa0b5515");
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Accept", "application/json");
                //var body = @"{""pinType"":""NUMERIC"",""messageText"":""Your pin is {{1234}}"",""pinLength"":4,""senderId"":""447491163443""}";
                //request.AddStringBody(body, DataFormat.Json);
                //RestResponse response = await client.ExecuteAsync(request);
                //Console.WriteLine(response.Content);

                //var options = new RestClientOptions("https://6gq91r.api.infobip.com")
                //{
                //    MaxTimeout = -1,
                //};
                //var client = new RestClient(options);
                //var request = new RestRequest($"/2fa/2/applications/{appId}/messages", Method.Post);
                //request.AddHeader("Authorization", "App 7fab01a8b441a0d6220abdd6d0dfc22d-c7822494-bdce-4c0e-abb3-ed1eaa0b5515");
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Accept", "application/json");
                //var body = @"{""pinType"":""NUMERIC"",""messageText"":""Your pin is {{1234}}"",""pinLength"":4,""senderId"":""447491163443""}";
                //request.AddStringBody(body, DataFormat.Json);
                //RestResponse response = await client.ExecuteAsync(request);
                //Console.WriteLine(response.Content);

                //var options = new RestClientOptions("https://6gq91r.api.infobip.com")
                //{
                //    MaxTimeout = -1,
                //};
                //var client = new RestClient(options);
                //var request = new RestRequest("/2fa/2/pin", Method.Post);
                //request.AddHeader("Authorization", "App 7fab01a8b441a0d6220abdd6d0dfc22d-c7822494-bdce-4c0e-abb3-ed1eaa0b5515");
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Accept", "application/json");
                //var body = @"{""applicationId"":""D7BEF06056291A4B375BBAC62166D9FC"",""messageId"":""AF434EAA207C3279BF5F6ECD350300C8"",""from"":""447491163443"",""to"":""201144763065""}";
                //request.AddStringBody(body, DataFormat.Json);
                //RestResponse response = await client.ExecuteAsync(request);
                //Console.WriteLine(response.Content);

                //var options = new RestClientOptions("https://6gq91r.api.infobip.com")
                //{
                //    MaxTimeout = -1,
                //};
                //var client = new RestClient(options);
                //var request = new RestRequest("/2fa/2/pin/C56D0D4CDF39D51EA61E0E5E1E388848/verify", Method.Post);
                //request.AddHeader("Authorization", "App 7fab01a8b441a0d6220abdd6d0dfc22d-c7822494-bdce-4c0e-abb3-ed1eaa0b5515");
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Accept", "application/json");
                //var body = @"{""pin"":""1234""}";
                //request.AddStringBody(body, DataFormat.Json);
                //RestResponse response = await client.ExecuteAsync(request);
                //Console.WriteLine(response.Content);













                //var options = new RestClientOptions("https://6gq91r.api.infobip.com")
                //{
                //    MaxTimeout = -1,
                //};
                //var client = new RestClient(options);
                //var request = new RestRequest("/sms/2/text/advanced", Method.Post);
                //request.AddHeader("Authorization", "App 7fab01a8b441a0d6220abdd6d0dfc22d-c7822494-bdce-4c0e-abb3-ed1eaa0b5515");
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Accept", "application/json");
                //var body = @"{""messages"":[{""destinations"":[{""to"":""201287178883""}],""from"":""ServiceSMS"",""text"":""Congratulations on sending your first message.\nGo ahead and check the delivery report in the next step.""}]}";
                //request.AddStringBody(body, DataFormat.Json);
                //RestResponse response = await client.ExecuteAsync(request);
                //  Console.WriteLine(response.Content);

                // Console.WriteLine(response.Content);



                //var options = new RestClientOptions("https://6gq91r.api.infobip.com")
                //{
                //    MaxTimeout = -1,
                //};
                //var client = new RestClient(options);
                //var request = new RestRequest("/sms/2/text/advanced", Method.Post);
                //request.AddHeader("Authorization", "App 7fab01a8b441a0d6220abdd6d0dfc22d-c7822494-bdce-4c0e-abb3-ed1eaa0b5515");
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Accept", "application/json");
                //var body = @"{""messages"":[{""destinations"":[{""to"":""201203592922""}],""from"":""Correct"",""text"":""Hi, Your Verification OTP is 521124 ""}]}";
                //request.AddStringBody(body, DataFormat.Json); // + 201064309627
                //RestResponse response = await client.ExecuteAsync(request);
                ////Console.WriteLine(response.Content);

                return Ok("response.Content");
            }
            catch (Exception ex)
            {
                return StatusCode(501, ex.Message);
            }
        }

    }
}
