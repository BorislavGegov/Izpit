using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestingLayer
{
    public class UnitTest_Region
    {
        private ActivityDbContext _dbContext;
        private RegionContext _regionContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _dbContext = new ActivityDbContext(builder.Options);
            _regionContext = new RegionContext(_dbContext);
        }
        //"reg"-region, "aft"-after, "befor"-before
        [Test]
        public void CreateRegion()
        {
            int regBefor = _regionContext.ReadAll().Count();
            _regionContext.Create(new Region("Kanto"));
            int regAft = _regionContext.ReadAll().Count();
            Assert.IsTrue(regBefor != regAft);
        }
        [Test]
        public void ReadRegion()
        {
            _regionContext.Create(new Region("Kanto"));
            Region region = _regionContext.Read(1);
            Assert.That(region != null, "There's no record with id 1");
        }
        [Test]
        public void UpdateRegion()
        {
            _regionContext.Create(new Region("Kanto"));
            Region region = _regionContext.Read(1);
            region.Name = "Johto";
            _regionContext.Update(region);
            Region regionAlt = _regionContext.Read(1);
            Assert.IsTrue(regionAlt.Name == "Johto", "Update() doesn't change anything...");
        }
        [Test]
        public void DeleteRegion()
        {
            _regionContext.Create(new Region("Delet this pls"));
            int regBeforDel = _regionContext.ReadAll().Count();
            _regionContext.Delete(1);
            int regAftDel = _regionContext.ReadAll().Count();
            Assert.AreNotEqual(regBeforDel, regAftDel);
        }      
    }
}