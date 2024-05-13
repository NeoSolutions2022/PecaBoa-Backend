using PecaBoa.Application.Notification;
using PecaBoa.Core.Authorization;
using PecaBoa.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace PecaBoa.Api.Controllers.V1.Usuario;

[Authorize]
[ClaimsAuthorize("Usuario", ETipoUsuario.Usuario)]
public class MainController : BaseController
{
    protected MainController(INotificator notificator) : base(notificator)
    {
    }
}