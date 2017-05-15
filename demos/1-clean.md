
Task("Clean")
    .Does(() =>
{
    CleanDirectory(Directory("./artifacts"));
});

