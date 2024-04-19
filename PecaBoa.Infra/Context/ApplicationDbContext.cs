using PecaBoa.Core.Authorization;
using Microsoft.EntityFrameworkCore;

namespace PecaBoa.Infra.Context;

public sealed class ApplicationDbContext : BaseApplicationDbContext
{
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IAuthenticatedUser authenticatedUser) : base(options, authenticatedUser)
    {
    }
}