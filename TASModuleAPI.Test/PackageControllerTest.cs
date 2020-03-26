using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuleAPITest.Controllers;
using ModuleAPITest.Data;
using ModuleAPITest.Models;
using ModuleAPITest.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Xunit;

namespace TASModuleAPI.Test
{
    public class PackageControllerTest
    {
        private readonly Mock<IPackageRepository> _packageRepositoryMock;
        
        public PackageControllerTest()
        {
            _packageRepositoryMock = new Mock<IPackageRepository>();
        }
        [Fact]

        public async Task GetPackageTest()
        {
            //Arrange
            var package = new List<Package>() { new Package { Id = 1, ShortName = "gatik", Description = "It is a test ", Url = "https://software.broadinstitute.org/gatk/" } };
            _packageRepositoryMock.Setup(x => x.GetPackage()).ReturnsAsync(package);
            //Act
            var controller = new PackagesController(_packageRepositoryMock.Object);
            var result = await controller.GetPackage();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        public async Task GetPackageByIdTest()
        {
            //Arrange
            var id = 14;
            var package = new Package { Id = id };
            _packageRepositoryMock.Setup(x => x.GetPackageById(It.IsAny<int>())).ReturnsAsync(package);
            //Act
            var controller = new PackagesController(_packageRepositoryMock.Object);
            var result = await controller.GetPackageById(id);
            //Assert
            Assert.NotNull(result);            

        }

        [Fact]
        public async Task PostPackage_Add_data() 
        {
            //Arrange
            var packagelist = new List<PackageIngestModel>() { new PackageIngestModel() { Id = 1, package = "gatik", description = "It is a test ", url = "https://software.broadinstitute.org/gatk/", versions = new List<VersionIngestModel>() } };
        
            var package = new Package { Id = 1, ShortName = "gatik", Description = "It is a test ", Url = "https://software.broadinstitute.org/gatk/" };
            _packageRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Package>())).Returns(Task.CompletedTask);
            _packageRepositoryMock.Setup(x => x.packageExists(package));

            //Act
            var controller = new PackagesController(_packageRepositoryMock.Object);
            var result = await controller.PostPackage(packagelist);
            
            //Assert
            Assert.NotNull(result);
            _packageRepositoryMock.Verify(m => m.CreateAsync(It.IsAny<Package>()), Times.Once);

        }

        [Fact]
        public async Task PostPackages_Return_BadRequest()
        {
            // Arrange
            List<PackageIngestModel> package = null;
            // Act
            // Assert
            try
            {
                var controller = new PackagesController(_packageRepositoryMock.Object);
                var result = await controller.PostPackage(package);
            }
            catch (HttpResponseException ex)
            {
                Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                throw;
            }
        }
    }
}
