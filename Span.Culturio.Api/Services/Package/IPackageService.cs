using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Services.Package
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageDto>> GetPackages();
    }
}

