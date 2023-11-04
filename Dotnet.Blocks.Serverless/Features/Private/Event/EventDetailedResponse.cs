namespace Dotnet.Blocks.Serverless.Features.Private.Event;

public record EventDetailedResponse(Guid Uid, string Name, string Description, DateTimeOffset StartTime, DateTimeOffset EndTime);