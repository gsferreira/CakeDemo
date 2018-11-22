///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
.Does(() =>
{
    CleanDirectory(Directory("./artifacts"));
});

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

Task("Unit-Tests")
.IsDependentOn("Build")
.Does(() =>
{
    DotNetCoreTest("./src/WebApplication.Tests/WebApplication.Tests.csproj");
});

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

Task("Default")
.IsDependentOn("Publish")
.Does(() => {
   Information("Hello Cake!");
});

RunTarget(target);