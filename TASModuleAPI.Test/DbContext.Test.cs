using Microsoft.EntityFrameworkCore;
using ModuleAPITest.Controllers;
using ModuleAPITest.Data;
using ModuleAPITest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TASModuleAPI.Test
{
    public class DbContext
    {
        [Fact]
        public void Add()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SoftwareModulesContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;

            var package = new Package() { Id = 1, ShortName = "gatik", Description = "It is a test ", Url = "https://software.broadinstitute.org/gatk/" };

            using (var context = new SoftwareModulesContext(options))
            {

                //var controller = new PackagesController();

                context.Add(package);
                context.SaveChanges();

            }

            // Act
            // Assert
            using (var context = new SoftwareModulesContext(options))
            {
                Assert.Equal(1, context.Package.Count());
                Assert.Equal("https://software.broadinstitute.org/gatk/", context.Package.Single().Url);
            }

        }
    }
}
