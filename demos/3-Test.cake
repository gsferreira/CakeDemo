var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


Task("Clean")
    .Does(() =>
{
    CleanDirectory(Directory("./artifacts"));
});

Task("Build")
    .IsDependentOn("Clean")
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