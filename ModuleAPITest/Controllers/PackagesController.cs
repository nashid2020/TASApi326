using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuleAPITest.Data;
using ModuleAPITest.Models;
using ModuleAPITest.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        //private readonly SoftwareModulesContext _context;
        private readonly IPackageRepository _packageRepository;

        public PackagesController(IPackageRepository packageRepository)
        {
           // _context = context;
            _packageRepository = packageRepository;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<IEnumerable<Package>> GetPackage()
        {
            //return await _context.Package.Include(p => p.Versions)
            //                                .ThenInclude(v => v.MachineVersions)
            //                                .ThenInclude(mv => mv.MachineVersionsModulePath)
            //                                .ToListAsync();
            return await _packageRepository.GetPackage();
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackageById(int id)
        {
            //var package = await _context.Package.FindAsync(id);
            Package package = await _packageRepository.GetPackageById(id);

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPackage(int id, Package package)
        //{
        //    if (id != package.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(package).State = EntityState.Modified;

        //    try
        //    {
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PackageExists(id))
            //    {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Packages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(List<PackageIngestModel> packageingestmodel)
        {
            if (packageingestmodel == null)
            {
                return BadRequest();
            }
                
            foreach (var packageDTO in packageingestmodel)
            { 
                Package packages = new Package
                {
                    ShortName = packageDTO.package,
                    Description = packageDTO.description,
                    Url = packageDTO.url,
                    //TopicId = 1
                };

                //var packageexists = _context.Package.FirstOrDefault(p => p.ShortName == packages.ShortName);

                var packageexists = _packageRepository.packageExists(packages);

                if (packageexists != null) { return BadRequest("Owner object already exists"); }

                foreach (var v in packageDTO.versions)
                {
                    var versions = new Versions
                    {
                        Id = v.Id,
                        Name = v.versionName,
                    };

                    versions.MachineVersions = new List<MachineVersions>
                    {
                        new MachineVersions
                        {
                            CanonicalVersion = v.canonicalVersionString,
                            Versions = versions,
                            Documentation = v.help,
                            MachineVersionsModulePath = new List<MachineVersionsModulePath>
                                            {
                                                new MachineVersionsModulePath
                                                {
                                                    ModulePath = new ModulePath
                                                    {
                                                        Value = v.path
                                                    }
                                                }
                                            }
                        }
                    };

                        packages.Versions.Add(versions);
                }

                await _packageRepository.CreateAsync(packages);
                //_context.Package.Add(packages);
                //await _context.SaveChangesAsync();

                return CreatedAtAction("GetPackage", new { id = packages.Id }, packages);
            }
            
            return Ok();
            
        }

        //public async Task<ActionResult<Package>> PostPackage(Package package)
        //{
        //    _context.Package.Add(package);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        //}

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Package>> DeletePackage(int id)
        {
            var package = await _packageRepository.GetPackageById(id);
            if (package == null)
            {
                return NotFound();
            }

            await _packageRepository.DeletePackage(package, id);
            //_context.Package.Remove(package);
            //await _context.SaveChangesAsync();

            return package;
        }

        //private bool PackageExists(int id)
        //{
        //    return _context.Package.Any(e => e.Id == id);
        //}
    }
}
