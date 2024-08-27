using Microsoft.AspNetCore.SignalR;
using Service.Abstraction.IHubServices;

namespace CorrectAcademy_API.Hubs
{
    public class CorrectHub : Hub<IHubMethods>
    {
        public override Task OnConnectedAsync()
        {   
            var classIds = new List<string>();


            // Add User To all Classes Groups
            classIds.ForEach( async cl => 
            await Groups.AddToGroupAsync(Context.ConnectionId, cl));

            // Notify Users in Classes Chat that user is currently connected  
            Clients.Groups(classIds).UserConnected(Context.UserIdentifier!); 
            
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            // Remove User from all Classes Groups
            
            var classIds = new List<string>();
            // Notify Users in Classes Chat that user is currently disconnected  
            Clients.Groups(classIds).UserDisConnected(Context.UserIdentifier!);
            
            return base.OnDisconnectedAsync(exception);
        }
    }
}
