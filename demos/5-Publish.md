
Task("Publish")
    .IsDependentOn("Unit-Tests")
    .Does(() =>
{
    var settings = new DotNetCorePublishSettings
    {
        Framework = "netcoreapp1.1",
        Configuration = configuration,
        OutputDirectory = "./artifacts/publish"
    };
        
    DotNetCorePublish("./src/WebApplication/", settings);
});

