using PecaBoa.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Contracts;

public interface IFileService
{
    Task<string> Upload(IFormFile arquivo);
}