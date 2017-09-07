using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using AskToniApi.Controllers;
using AskToniApi.Models;
using TestsCore;

namespace AskToniApi.UnitTests.Controllers
{
    public class RestaurantControllerUnitTests
    {
        [Fact]
        public void Get_Success_ReturnsCorrectResult()
        {
            var mockRecommendationRepository = new Mock<IRecommendationRepository>();
            var restaurantCollection = new List<Restaurant>();
            restaurantCollection.Add(new Restaurant() 
                                        { 
                                            RestaurantName = "testName",
                                            ReviewCount = 2
                                        }
                                    );
            mockRecommendationRepository.Setup(d => d.GetAllRestaurants()).ReturnsAsync(restaurantCollection);

            var recommendationController = new RestaurantController(mockRecommendationRepository.Object);
            var result = recommendationController.Get();
            Assert.Equal("testName",result.Result.First().RestaurantName);
        }
    }
}
