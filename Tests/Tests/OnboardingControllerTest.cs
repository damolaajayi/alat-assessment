using assessment.Controllers;
using Contracts;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Tests
{
    public class OnboardingControllerTest
    {
        private Mock<OnboardingInterface> _onboarding;
        private OnboardingController _controller;
        private readonly LoggerManager _logger;

        public OnboardingControllerTest()
        {
            
            _logger = new LoggerManager();
           _onboarding = new Mock<OnboardingInterface>();
            _controller = new OnboardingController(_onboarding.Object, _logger);
            
        }

       

        [Fact]
        public void GetAllUsersTest()
        {
            var result = _controller.GetUsers();
            //Assert.IsType<OkObjectResult>(result.Result);
            var listOfUsers = result.Result as OkObjectResult;
            Assert.IsType<List<Onboard>>(listOfUsers?.Value);

        }


        [Fact]
        public void Create_User_Test()
        {
            var model = new Onboard { Email = "damolaajayi@gmail", Password = "S@deAdu123", 
                                      PhoneNumber = "07039121201"};
            var result = _controller.AddUser(model);
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public void GetAllBank_Test()
        {
            var result = _controller.GetAllBanks();
            Assert.IsType<OkObjectResult>(result.Result);

        }
    }
}
