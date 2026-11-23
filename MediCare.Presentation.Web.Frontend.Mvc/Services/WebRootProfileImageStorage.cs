using MediCare.IApplication.BackEnd.IAppService;

namespace MediCare.Presentation.Web.Frontend.Mvc.Services;

public sealed class WebRootProfileImageStorage : IProfileImageStorage
{
    private readonly IWebHostEnvironment _environment;

    public WebRootProfileImageStorage(IWebHostEnvironment environment) => _environment = environment;

    public async Task<string> StoreAsync(Stream image, string extension, CancellationToken cancellationToken = default)
    {
        var fileName = $"{Guid.NewGuid():N}{extension}";
        var folder = Path.Combine(_environment.WebRootPath ?? string.Empty, "uploads", "doctors");
        Directory.CreateDirectory(folder);

        var path = Path.Combine(folder, fileName);
        try
        {
            await using var file = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.None);
            await image.CopyToAsync(file, cancellationToken);
            return $"/uploads/doctors/{fileName}";
        }
        catch
        {
            if (File.Exists(path))
                File.Delete(path);
            throw;
        }
    }
}
