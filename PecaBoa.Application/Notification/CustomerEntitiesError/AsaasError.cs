namespace PecaBoa.Application.Notification.CustomerEntitiesError;

public class AsaasError
{
    public List<Error> Errors { get; set; } = new ();
}

public class Error
{
    public string Code { get; set; } = null!;
    public string Description { get; set; } = null!;
}