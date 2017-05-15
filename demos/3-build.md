
Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Package-Restore")
    .Does(() =>
{
    
     DotNetCoreBuild("./src/CakeDemo.sln");

});

