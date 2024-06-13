using Microsoft.AspNetCore.SignalR;

namespace PecaBoa.Api.Hubs;

public class ChatHub : Hub
{
    public async Task EnviarMensagem(string usuario, string mensagem)
    {
        await Clients.All.SendAsync("ReceberMensagem", usuario, mensagem);
    }
}