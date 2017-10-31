
Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration
    };


    DotNetCoreBuild("./src/CakeDemo.sln", settings);
});

