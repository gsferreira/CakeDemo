
Task("Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest("./src/WebApplication.Tests/WebApplication.Tests.csproj");
        
});
