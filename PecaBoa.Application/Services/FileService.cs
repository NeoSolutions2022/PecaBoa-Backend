using AutoMapper;
using Azure.Storage.Blobs;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Notification;
using PecaBoa.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace PecaBoa.Application.Services;

public class FileService : BaseService, IFileService
{
    private readonly IConfiguration _config;
    public FileService(IMapper mapper, INotificator notificator, IConfiguration config) : base(mapper, notificator)
    {
        _config = config;
    }

    public async Task<string> Upload(IFormFile arquivo)
    {
        var uploadDirectory = _config.GetValue<string>("UploadSettings:PublicBasePath");
        var fileName = GenerateNewFileName(arquivo.FileName);
        var filePath = Path.Combine(uploadDirectory, fileName);

        if (!Directory.Exists(uploadDirectory))
        {
            Directory.CreateDirectory(uploadDirectory);
        }

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await arquivo.CopyToAsync(stream);
        }

        return filePath;
    }

    private static string GenerateNewFileName(string name)
    {
        var newFileName = $"{Guid.NewGuid()}_{name}".ToLower();
        newFileName = newFileName.Replace("-", "");

        return newFileName;
    }
}