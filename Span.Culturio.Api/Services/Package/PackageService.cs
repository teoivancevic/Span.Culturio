using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Models;
using Span.Culturio.Api.Data;

namespace Span.Culturio.Api.Services.Package
{
    public class PackageService : IPackageService
    {

        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        

        public PackageService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        
        public async Task<IEnumerable<PackageDto>> GetPackages()
        {
            



            var packages = await _context.Packages.ToListAsync();

            var packagesDto = _mapper.Map<List<PackageDto>>(packages);
            return packagesDto;
        }

        public async Task<PackageDto> GetPackage(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            //package.CultureObjects = await _context.PackageCultureObjects.Where(x => x.Package.Id.Equals(package.Id)).ToListAsync();
            var packageDto = _mapper.Map<PackageDto>(package);
            return packageDto;
        }

        public async Task<PackageDto> CreatePackage(CreatePackageDto package)
        {
            var packageEntity = _mapper.Map<Data.Entities.Package>(package);
            _context.Packages.Add(packageEntity);

            await _context.SaveChangesAsync();

            var packageDto = _mapper.Map<PackageDto>(packageEntity);
            return packageDto;
        }




        public async Task<PackageCultureObjectDto> CreatePackageCultureObject(CreatePackageCultureObjectDto packageCultureObject)
        {
            var packageCultureObjectEntity = _mapper.Map<Data.Entities.PackageCultureObject>(packageCultureObject);
            //packageCultureObjectEntity.Package = _context.Packages.FindAsync(packageCultureObject.PackageId);
            _context.PackageCultureObjects.Add(packageCultureObjectEntity);

            await _context.SaveChangesAsync();

            var packageCultureObjectDto = _mapper.Map<PackageCultureObjectDto>(packageCultureObjectEntity);
            return packageCultureObjectDto;
        }




    }
}

