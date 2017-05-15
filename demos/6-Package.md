#tool "nuget:?package=OctopusTools"


Task("Package")
    .IsDependentOn("Publish")
    .Does(() =>
{
    var settings = new OctopusPackSettings {
        
        BasePath = "./artifacts/publish",
        OutFolder = "./artifacts/octo",
        Overwrite = true
    };
    OctoPack("webapp", settings);
});
