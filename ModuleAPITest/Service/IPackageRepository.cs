using Microsoft.AspNetCore.Mvc;
using ModuleAPITest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModuleAPITest.Service
{
    public interface IPackageRepository
    {
        Task<IEnumerable<Package>> GetPackage();
        Task<Package> GetPackageById(int id);
        Task DeletePackage(Package package, int id);
        Task CreateAsync(Package package);
        Package packageExists(Package packages);
    }
}