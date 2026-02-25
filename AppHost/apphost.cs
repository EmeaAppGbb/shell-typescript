#:sdk Aspire.AppHost.Sdk@13.1.0
#:package Aspire.Hosting.JavaScript@13.1.0

var builder = DistributedApplication.CreateBuilder(args);

// API — Express.js backend
var api = builder.AddJavaScriptApp("api", "../src/api")
    .WithHttpEndpoint(port: 5001, env: "PORT")
    .WithExternalHttpEndpoints();

// Web — Next.js frontend
builder.AddJavaScriptApp("web", "../src/web")
    .WithHttpEndpoint(port: 3000, env: "PORT")
    .WithExternalHttpEndpoints()
    .WithReference(api);

// Docs — MkDocs dev server
builder.AddExecutable("docs", "bash", "..", "-c", "mkdocs serve --dev-addr 0.0.0.0:$PORT")
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();

builder.Build().Run();
