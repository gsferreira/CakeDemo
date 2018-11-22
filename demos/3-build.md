
Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Package-Restore")
    .Does(() =>
{
    
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration
    };


    DotNetCoreBuild("./src/CakeDemo.sln", settings);
});

