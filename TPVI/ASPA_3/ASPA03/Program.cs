using Microsoft.Extensions.FileProviders;

var biulder = WebApplication.CreateBuilder(args);
var app = biulder.Build();
Repository.JsonFileName = "Celebrities.json";

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(Repository.directoryPath),
    RequestPath = "/Photo", 
});

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(Repository.directoryPath),
    RequestPath = "/download",
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Content-Disposition", "attachment");
    }
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(Repository.directoryPath),
    RequestPath = "/download"
});

using (IRepository repository = Repository.Create(Repository.directoryPath))
{
    app.MapGet("/Celebrities",()=>repository.GetAllCelebrities());
    app.MapGet("/Celebrities/{id:int}",(int id)=>repository.GetCelebrityById(id));
    app.MapGet("/Celebrities/BySurname/{surname}",(string surname)=>repository.GetCelebritiesBySurname(surname));
    app.MapGet("/Celebrities/PhotoPathById/{id:int}",(int id)=>repository.GetPhotoPathById(id));
    app.MapGet("/", () => "Hello World");
    app.Run();


}