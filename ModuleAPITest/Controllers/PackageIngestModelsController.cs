using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuleAPITest.Data;
using ModuleAPITest.Models.Package_old;


namespace ModuleAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageIngestModelsController : ControllerBase
    {
        private readonly ModuleAPIDBContext _context;

        public PackageIngestModelsController(ModuleAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/PackageIngestModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageIngestModel1>>> GetPackage()
        {
            return await _context.Package.Include(p => p.versions).ToListAsync();
        }

        // GET: api/PackageIngestModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageIngestModel1>> GetPackageIngestModel(int id)
        {
            //var packageIngestModel = await _context.Package.FindAsync(id);

            var packageIngestModel = await _context.Package.Include(p => p.versions).FirstOrDefaultAsync(p => p.Id == id);

            if (packageIngestModel == null)
            {
                return NotFound();
            }

            return packageIngestModel;
        }

        // PUT: api/PackageIngestModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackageIngestModel(int id, PackageIngestModel1 packageIngestModel)
        {
            if (id != packageIngestModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(packageIngestModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageIngestModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PackageIngestModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PackageIngestModel1>> PostPackageIngestModel(PackageIngestModel1 packageIngestModel1)
        {
            _context.Package.Add(packageIngestModel1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackageIngestModel", new { id = packageIngestModel1.Id }, packageIngestModel1);
        }

        // DELETE: api/PackageIngestModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PackageIngestModel1>> DeletePackageIngestModel(int id)
        {
            var packageIngestModel1 = await _context.Package.FindAsync(id);
            if (packageIngestModel1 == null)
            {
                return NotFound();
            }

            _context.Package.Remove(packageIngestModel1);
            await _context.SaveChangesAsync();

            return packageIngestModel1;
        }

        private bool PackageIngestModelExists(int id)
        {
            return _context.Package.Any(e => e.Id == id);
        }
    }
}
