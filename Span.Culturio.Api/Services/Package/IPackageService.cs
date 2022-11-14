using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Services.Package
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageDto>> GetPackages();
        Task<PackageDto> GetPackage(int id);

        Task<PackageDto> CreatePackage(CreatePackageDto package);

        Task<PackageCultureObjectDto> CreatePackageCultureObject(CreatePackageCultureObjectDto packageCultureObject);



    }
}

