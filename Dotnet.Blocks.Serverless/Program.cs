using Dotnet.Blocks.Serverless.Features.GraphQL;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services
    .AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddFastEndpoints();

builder.Services.AddScoped<IClock, Clock>();

var app = builder.Build();

app.UseRouting();
app.UseFastEndpoints();

app.UseEndpoints(endpoints =>
    endpoints.MapGraphQL());

await app.RunAsync();