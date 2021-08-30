using System;
using Xunit;
using AwsDotnetCsharp;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

namespace Profanity.Tests
{
    public class ProfanityTests
    {
        [Fact]
        public void DetectTest()
        {
            APIGatewayProxyRequest request = new APIGatewayProxyRequest() { Body = "Does he look like a bitch?" };
            APIGatewayProxyResponse resp = new APIGatewayProxyResponse();

            Environment.SetEnvironmentVariable("enableFin","false");
            Handler handler = new Handler();

            resp = handler.Detect(request);
            Assert.Equal(resp.StatusCode, 200);
            Assert.Equal(resp.Body, "NOT OK!");
        }
        [Fact]
        public void CensorTest()
        {
            APIGatewayProxyRequest request = new APIGatewayProxyRequest() { Body = "Does he look like a bitch?" };
            APIGatewayProxyResponse resp = new APIGatewayProxyResponse();

            Environment.SetEnvironmentVariable("enableFin","false");
            Handler handler = new Handler();

            resp = handler.Censor(request);
            Assert.Equal(resp.StatusCode, 200);
            Assert.Equal(resp.Body, "Does he look like a *****?");
        }
        [Fact]
        public void NoBodyTest()
        {
            APIGatewayProxyRequest request = new APIGatewayProxyRequest() {};
            APIGatewayProxyResponse resp = new APIGatewayProxyResponse();

            Environment.SetEnvironmentVariable("enableFin","false");
            Handler handler = new Handler();

            resp = handler.Censor(request);
            Assert.Equal(resp.StatusCode, 400);
            Assert.Equal(resp.Body, "No input provided");
        }
    }
}
