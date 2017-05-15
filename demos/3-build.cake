var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


Task("Clean")
    .Does(() =>
{
    CleanDirectory(Directory("./artifacts"));
});

Task("Package-Restore")
    .Does(() =>
{
    DotNetCoreRestore("./src/CakeDemo.sln");
});

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


Task("Default")
    .IsDependentOn("Build");

RunTarget(target);