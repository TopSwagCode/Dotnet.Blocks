namespace Dotnet.Blocks.Serverless.Features.Private.Event;

public record EventResponse(Guid Uid, string Name, DateTimeOffset StartTime);