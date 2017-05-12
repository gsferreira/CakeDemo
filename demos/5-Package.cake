#tool "OctopusTools"

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
        OutputDirectory = "./bin/"
    };
    
     DotNetCoreBuild("./src/CakeDemo.sln", settings);

});

Task("Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest("./src/WebApplication.Tests/WebApplication.Tests.csproj");
        
});

Task("Package")
    .IsDependentOn("Unit-Tests")
    .Does(() =>
{
    var settings = new OctopusPackSettings {
        
        BasePath = "./bin/",
        OutFolder = "./artifacts",
        Overwrite = true
    };
    OctoPack("webapp", settings);
});

Task("Default")
    .IsDependentOn("Package");


RunTarget(target);