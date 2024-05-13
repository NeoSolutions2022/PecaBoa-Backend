using PecaBoa.Application.Notification;
using Microsoft.AspNetCore.Authorization;

namespace PecaBoa.Api.Controllers.V1.Lojista;

[Authorize]
public class MainController : BaseController
{
    protected MainController(INotificator notificator) : base(notificator)
    {
    }
}