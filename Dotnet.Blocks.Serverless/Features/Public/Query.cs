using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.RuntimeInformation;
//https://chillicream.com/docs/hotchocolate/v13/integrations/entity-framework
namespace Dotnet.Blocks.Serverless.Features.GraphQL
{
    public class Query
    {
        public string SysInfo => $"{FrameworkDescription} running on {RuntimeIdentifier}";
        public string Hello => "World";
        public Book Book => new()
        {
            Description = "Awesome book about trains",
            Id = 1337,
            Title = "Trains and stuff",
            Author = new()
            {
                Age = 4,
                Name = "Storm"
            }
        };

        public long GetEpochTime2([Service] IClock clock)
        {
            return clock.UtcNow.ToUnixTimeMilliseconds();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public Person Author { get; set; }
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


    public interface IClock
    {
        DateTimeOffset UtcNow { get; }
    }

    public class Clock : IClock
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

    }
}
