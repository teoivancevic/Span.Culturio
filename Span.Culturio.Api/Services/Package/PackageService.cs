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
        //private readonly IAccountService _accountService;

        public PackageService(DataContext context, IMapper mapper/*, IAccountService accountService*/)
        {
            _context = context;
            _mapper = mapper;
            //_accountService = accountService;
        }

        
        public async Task<IEnumerable<PackageDto>> GetPackages()
        {
            var packages = await _context.Packages.ToListAsync();
            var packagesDto = _mapper.Map<List<PackageDto>>(packages);
            return packagesDto;
        }
        


    }
}

