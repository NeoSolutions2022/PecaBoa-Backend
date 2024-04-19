using PecaBoa.Application.Notification;
using PecaBoa.Core.Authorization;
using PecaBoa.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace PecaBoa.Api.Controllers.V1.Cliente;

[Authorize]
[ClaimsAuthorize("Cliente", ETipoUsuario.Cliente)]
public class MainController : BaseController
{
    protected MainController(INotificator notificator) : base(notificator)
    {
    }
}