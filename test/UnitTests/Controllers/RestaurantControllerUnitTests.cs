using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using AskToniApi.Controllers;
using AskToniApi.Models;

namespace AskToniApi.UnitTests.Controllers
{
    public class RestaurantControllerUnitTests
    {
        [Theory,
        InlineData(0,1)]
        public void Get_Success_ReturnsCorrectResult(int pageOffset, int pageLimit)
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

            var restaurantController = new RestaurantController(mockRecommendationRepository.Object);
            var result = restaurantController.Get(pageOffset,pageLimit);
            Assert.Equal("testName",result.Result.First().RestaurantName);
        }
    }
}
