using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuleAPITest.Data;
using ModuleAPITest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleAPITest.Service
{
    public class PackageRepository : IPackageRepository
    {
        private readonly SoftwareModulesContext _context;

        public PackageRepository(SoftwareModulesContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Package>> GetPackage()
        {
            return await _context.Package.Include(p => p.Versions)
                                            .ThenInclude(v => v.MachineVersions)
                                            .ThenInclude(mv => mv.MachineVersionsModulePath)
                                            .ToListAsync();
        }

        public async Task<Package> GetPackageById(int id)
        {
            return await _context.Package.Include(p => p.Versions)
                                                    .ThenInclude(v => v.MachineVersions)
                                                    .ThenInclude(mv => mv.MachineVersionsModulePath)
                                                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeletePackage(Package package, int id)
        {
            _context.Package.Remove(package);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Package packages)
        {
            _context.Package.Add(packages);
            await _context.SaveChangesAsync();
        }

        public Package packageExists(Package packages)
        {
            return _context.Package.FirstOrDefault(p => p.ShortName == packages.ShortName);
        }
    }
}
