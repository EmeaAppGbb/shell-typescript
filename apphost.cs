#:sdk Aspire.AppHost.Sdk@13.1.0
#:package Aspire.Hosting.JavaScript@13.1.0

var builder = DistributedApplication.CreateBuilder(args);

// API — Express.js / TypeScript backend
var api = builder.AddJavaScriptApp("api", "./src/api")
    .WithHttpHealthCheck("/health");

// Web — Next.js frontend
builder.AddJavaScriptApp("web", "./src/web")
    .WithExternalHttpEndpoints()
    .WithReference(api)
    .WaitFor(api);

builder.Build().Run();
