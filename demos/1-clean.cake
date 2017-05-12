var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


Task("Clean")
    .Does(() =>
{
    CleanDirectory(Directory("./artifacts"));
});


Task("Default")
    .IsDependentOn("Clean");

RunTarget(target);