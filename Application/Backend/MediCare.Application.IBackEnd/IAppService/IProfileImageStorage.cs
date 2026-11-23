namespace MediCare.IApplication.BackEnd.IAppService;

public interface IProfileImageStorage
{
    Task<string> StoreAsync(Stream image, string extension, CancellationToken cancellationToken = default);
}
