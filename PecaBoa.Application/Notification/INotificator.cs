using FluentValidation.Results;
using PecaBoa.Application.Notification.CustomerEntitiesError;

namespace PecaBoa.Application.Notification;

public interface INotificator
{
    void Handle(string message);
    void Handle(List<ValidationFailure> failures);
    public void Handle(AsaasError asaasError);
    void HandleNotFoundResource();
    IEnumerable<string> GetNotifications();
    bool HasNotification { get; }
    bool IsNotFoundResource { get; }
}