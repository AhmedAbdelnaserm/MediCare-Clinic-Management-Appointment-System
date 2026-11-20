using System.Text.RegularExpressions;
using MediCare.Application.BackEnd.Storage;
using Microsoft.Extensions.Configuration;

namespace MediCare.Infrastructure.Repository.Storage;

public sealed class PrivateAttachmentStorage : IPrivateAttachmentStorage
{
    private static readonly HashSet<string> AllowedExtensions = [".pdf", ".png", ".jpg", ".jpeg"];
    private readonly string _rootPath;

    public PrivateAttachmentStorage(IConfiguration configuration)
    {
        var configuredRoot = configuration["PrivateStorage:RootPath"];
        _rootPath = Path.GetFullPath(string.IsNullOrWhiteSpace(configuredRoot)
            ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MediCare", "attachments")
            : configuredRoot);
        Directory.CreateDirectory(_rootPath);
    }

    public async Task<string> SaveAsync(Stream content, string extension, CancellationToken cancellationToken = default)
    {
        if (!AllowedExtensions.Contains(extension))
            throw new InvalidOperationException("Unsupported private attachment extension.");
        var key = $"{Guid.NewGuid():N}{extension}";
        var path = ResolvePath(key);
        await using var output = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.None,
            81920, FileOptions.Asynchronous | FileOptions.SequentialScan);
        await content.CopyToAsync(output, cancellationToken);
        return key;
    }

    public Task<Stream> OpenReadAsync(string storageKey, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Stream stream = new FileStream(ResolvePath(storageKey), FileMode.Open, FileAccess.Read, FileShare.Read,
            81920, FileOptions.Asynchronous | FileOptions.SequentialScan);
        return Task.FromResult(stream);
    }

    public Task DeleteAsync(string storageKey, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var path = ResolvePath(storageKey);
        if (File.Exists(path))
            File.Delete(path);
        return Task.CompletedTask;
    }

    private string ResolvePath(string key)
    {
        var extension = Path.GetExtension(key);
        var name = Path.GetFileNameWithoutExtension(key);
        if (!AllowedExtensions.Contains(extension) || !Regex.IsMatch(name, "^[a-fA-F0-9]{32}$"))
            throw new InvalidOperationException("Invalid private attachment storage key.");
        return Path.Combine(_rootPath, key);
    }
}
