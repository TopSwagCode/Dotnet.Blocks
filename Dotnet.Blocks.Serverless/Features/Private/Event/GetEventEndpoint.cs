using FastEndpoints;
using FluentValidation;

namespace Dotnet.Blocks.Serverless.Features.Private.Event
{
    public class GetEventEndpoint : Endpoint<GetEventEndpointRequest, GetEventEndpointResponse>
    {
        public override void Configure()
        {
            Get("/api/event/{Uid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetEventEndpointRequest req, CancellationToken ct)
        {
            // Get stuff from database and return.

            await SendAsync(new (Guid.NewGuid(), "Lego Con","asdas", DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(1)));
        }
    }

    public class GetEventEndpointValidator : Validator<GetEventEndpointRequest>
    {
        public GetEventEndpointValidator()
        {
            RuleFor(x => x.Uid)
                .NotEmpty()
                .WithMessage("Uid is required!").WithErrorCode("1337");
        }
    }

    public record GetEventEndpointRequest(Guid Uid);

    public record GetEventEndpointResponse(Guid Uid, string Name, string Description, DateTimeOffset StartTime, DateTimeOffset EndTime) : EventDetailedResponse(Uid, Name, Description, StartTime, EndTime);
}
