namespace PecaBoa.Domain.Contracts;

public interface IUnitOfWork
{
    Task<bool> Commit();
}