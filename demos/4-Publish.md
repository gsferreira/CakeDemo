
Task("Publish")
    .IsDependentOn("Unit-Tests")
    .Does(() =>
{
    var settings = new DotNetCorePublishSettings
    {
        Configuration = configuration,
        OutputDirectory = "./artifacts/publish"
    };
        
    DotNetCorePublish("./src/WebApplication/", settings);
});

