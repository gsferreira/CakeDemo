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
    
     DotNetCoreBuild("./src/CakeDemo.sln");

});

Task("Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest("./src/WebApplication.Tests/WebApplication.Tests.csproj");
        
});


Task("Default")
    .IsDependentOn("Unit-Tests");


RunTarget(target);