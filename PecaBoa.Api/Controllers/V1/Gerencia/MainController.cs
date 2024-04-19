using PecaBoa.Application.Notification;
using PecaBoa.Core.Authorization;
using PecaBoa.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace PecaBoa.Api.Controllers.V1.Gerencia;

[Authorize]
[ClaimsAuthorize("Administrador", ETipoUsuario.Administrador)]
public abstract class MainController : BaseController
{
    protected MainController(INotificator notificator) : base(notificator)
    {
    }
}