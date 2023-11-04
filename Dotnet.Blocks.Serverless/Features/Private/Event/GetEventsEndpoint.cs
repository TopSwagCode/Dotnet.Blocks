using FastEndpoints;
using static Dotnet.Blocks.Serverless.Features.Private.Event.GetEventsEndpoint;

namespace Dotnet.Blocks.Serverless.Features.Private.Event;

public class GetEventsEndpoint : EndpointWithoutRequest<GetEventsEndpointResponse>
{
    public override void Configure()
    {
        Get("/api/event/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        // Get stuff from database and return.

        await SendAsync(new(new() { new(Guid.NewGuid(), "Lego Con", DateTimeOffset.UtcNow) }, 1));
    }

    public record GetEventsEndpointResponse(List<EventResponse> Data, int Total);
}