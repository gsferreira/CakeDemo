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
    
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration
    };


    DotNetCoreBuild("./src/CakeDemo.sln", settings);

});


Task("Default")
    .IsDependentOn("Build");

RunTarget(target);