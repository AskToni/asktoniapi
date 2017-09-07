using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AskToniApi;
using AskToniApi.Controllers;
using AskToniApi.Models;
using Xunit;

namespace AskToniApi.IntegrationTests.Controllers
{
    public class RecommendationControllerIntegTests : IClassFixture<TestFixture<AskToniApi.Startup>>
    {
        private readonly HttpClient _client;

        public RecommendationControllerIntegTests(TestFixture<AskToniApi.Startup> fixture)
        {
            _client = fixture.Client;
        }

    }
}