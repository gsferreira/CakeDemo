
Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Package-Restore")
    .Does(() =>
{
    
    var settings = new DotNetCoreBuildSettings
    {
        Framework = "netcoreapp1.1",
        Configuration = configuration
    };


    DotNetCoreBuild("./src/CakeDemo.sln", settings);
});

