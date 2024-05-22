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
        var connectionString = _config.GetValue<string>("UploadConnectionString");
        var fileName = GenerateNewFileName(arquivo.FileName);
        var containerName = _config.GetValue<string>("UploadContainerName");
        
        BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
        BlobClient blob = container.GetBlobClient(fileName);
        await blob.UploadAsync(arquivo.OpenReadStream());

        return blob.Uri.AbsoluteUri;
    }

    private static string GenerateNewFileName(string name)
    {
        var newFileName = $"{Guid.NewGuid()}_{name}".ToLower();
        newFileName = newFileName.Replace("-", "");

        return newFileName;
    }
}