using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.RuntimeInformation;
//https://chillicream.com/docs/hotchocolate/v13/integrations/entity-framework
namespace Dotnet.Blocks.Serverless.Features.GraphQL
{
    public class Query
    {
        public string SysInfo => $"{FrameworkDescription} running on {RuntimeIdentifier}";
        public string Hello => "World";
    }

    public class Mutation
    {
        public Task<SignupResponse> SignupToEvent(int eventId)
        {
            return Task.FromResult(new SignupResponse(eventId));
        }
        /* 
        mutation SignupToEvent($eventId: Int!)
        {
            signupToEvent(eventId: $eventId){
                eventId
            }
        }
        */

        /* Variable
        {
            "eventId": 1
        }
        */
}

    public record SignupRequest(int eventId);
    public record SignupResponse(int eventId);
}
