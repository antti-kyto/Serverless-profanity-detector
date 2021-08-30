using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsDotnetCsharp
{
    public class Handler
    {
        ProfanityFilter.ProfanityFilter filter = new ProfanityFilter.ProfanityFilter();
        APIGatewayProxyResponse noBody = new APIGatewayProxyResponse
        {
            StatusCode = 400,
            Body = "No input provided"
        };

        void Init()
        {
            if (bool.Parse(System.Environment.GetEnvironmentVariable("enableFin")))
            {
                filter.AddProfanity(Finnish.finnishWordList);
            }
        }

        public APIGatewayProxyResponse Detect(APIGatewayProxyRequest request)
        {

            Init();
            string bodyString = request?.Body;

            if (string.IsNullOrEmpty(bodyString))
            {
                return noBody;
            }


            var swearList = filter.DetectAllProfanities(bodyString);

            // No profanities found
            if (swearList.Count <= 0)
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = "OK!"
                };
            }

            // Profanities found
            return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = "NOT OK!"
            };
        }

        public APIGatewayProxyResponse Censor(APIGatewayProxyRequest request)
        {

            Init();
            string bodyString = request?.Body;

            if (string.IsNullOrEmpty(bodyString))
            {
                return noBody;
            }

            string censored = filter.CensorString(bodyString);

            return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = censored
            };
        }
    }
}
