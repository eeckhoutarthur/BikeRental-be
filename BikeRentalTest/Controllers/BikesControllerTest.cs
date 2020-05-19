using BikeRentalTest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using ProjectBikeRental.Controllers;
using ProjectBikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace BikeRentalTest.Controllers
{
    public class BikesControllerTest
    {
        private readonly BikesController _bikesController;
        private readonly DummyDbContext _dbContext;
        private readonly Mock<IBikeRepository> _bikeRepo;

        public BikesControllerTest()
        {
            _dbContext = new DummyDbContext();
            _bikeRepo = new Mock<IBikeRepository>();
            _bikesController = new BikesController(_bikeRepo.Object);
        }

        [Fact]
        public void Get_GeeftBikeMetOvereenkomstigeId()
        {
            _bikeRepo.Setup(s => s.GetBy(1)).Returns(_dbContext.alleBikes[0]);
            var result = Assert.IsType<ActionResult<Bike>>(_bikesController.Get(1));
            Assert.Equal("Tarmac", result.Value.Name);
        }

        [Fact]
        public void Get_MetOnbestaandId_WerptNotFound()
        {
            Assert.IsType<NotFoundResult>(_bikesController.Get(10).Result);
        }

        [Fact]
        public void GetAll_GeeftAlleBikesTerug()
        {
            _bikeRepo.Setup(s => s.GetAll()).Returns(_dbContext.alleBikes);
            var result = Assert.IsAssignableFrom<IEnumerable<Bike>>(_bikesController.GetBikes());
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void CreateBike_MaaktEenFiets()
        {
            Bike bike = new Bike("Venge", BrandEnum.Specialized, Groupset.Shimano, BikeType.Road_Bike, true, 10m);

            var result = _bikesController.CreateBike(bike);
            Assert.IsType<ActionResult<Bike>>(result);
        }
    }
}
