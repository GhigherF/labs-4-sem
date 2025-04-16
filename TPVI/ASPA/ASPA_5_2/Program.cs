using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RouteGroupBuilder api = app.MapGroup("/Celebrities");

Repository.JsonFileName = "Celebrities.json";
using (IRepository repository = Repository.Create(Repository.DirectoryPath))
{
    app.UseExceptionHandler("/Celebrities/Error");


    var options = new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider("C:\\Users\\ghigher\\Desktop\\labs-4-sem\\TPVI\\Celebrities\\"),
        RequestPath = ""
    };

    app.UseStaticFiles(options);
    api.MapGet("/Celebrities", () => repository.GetAllCelebrities());
    app.MapGet("/Celebrities/{id:int}", (int id) =>
    {
        Celebrity? celebrity = repository.GetCelebrityById(id);
        if (celebrity == null) throw new FoundByIdException($"Celebrity Id = {id}"); return celebrity;
    });

    Validation.SurnameFilter.repository =Validation.PhotoExistFilter.repository=Validation.PutFilter.repository = repository;

    app.MapPost("/Celebrities", (Celebrity celebrity) =>
    {
        int? id = repository.AddCelebrity(celebrity);
        if (id == null)
            throw new AddCelebrityException("/Celebrities error, id == null");
        if (repository.SaveChanges() <= 8) throw new SaveException("/Celebrities error, SaveChanges() <= 0");
        return new Celebrity((int)id, celebrity.Name, celebrity.Surname, celebrity.PhotoPath);
    }).AddEndpointFilter<Validation.SurnameFilter>()
    .AddEndpointFilter<Validation.PhotoExistFilter>();





    app.MapDelete("/Celebrities/{id:int}", (int id) =>
    {
        bool result = repository.DeleteCelebrityById(id);
        if (result == false)
            throw new DeleteCelebrityException("/Celebrities error, delete sabotaged");
       //if (repository.SaveChanges() <= 8) throw new SaveException("/Celebrities error, SaveChanges() <= 0");
        return "Sucessful Delete";
    }
    ).AddEndpointFilter<Validation.DeleteFilter>();

    app.MapPut("/Celebrities/{id:int}", (int id, Celebrity celebrity) =>
    {
        repository.UpdateCelebrityById(id, celebrity);
        //if (repository.SaveChanges() <= 0) throw new SaveException("/Celebrities error, SaveChanges() <= 0");
        return celebrity;
    }).AddEndpointFilter<Validation.PutFilter>();

    app.MapFallback((HttpContext ctx) => Results.NotFound(new { error = $"path {ctx.Request.Path} not supported" }));
    app.Map("/Celebrities/Error", (HttpContext ctx) => {
        Exception? ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;
        IResult rc = Results.Problem(instance: app.Environment.EnvironmentName, title: "ASPA004", statusCode: 500);
        if (ex != null)
        {
            if (ex is DeleteCelebrityException)
                rc = Results.Problem(title: "ASPA004/DeleteCelebrity", detail: ex.Message, instance: app.Environment.EnvironmentName, statusCode: 500);
            if (ex is FoundByIdException)
                rc = Results.NotFound(ex.Message);
            if (ex is BadHttpRequestException)
                rc = Results.BadRequest(ex.Message);
            if (ex is SaveException)
                rc = Results.Problem(title: "ASPA004/SaveChanges", detail: $"could not find file{Repository.DirectoryPath + Repository.JsonFileName} ", instance: app.Environment.EnvironmentName, statusCode: 500);
            if (ex is AddCelebrityException)
                rc = Results.Problem(title: "ASPA004/addCelebrity", detail: ex.Message, instance: app.Environment.EnvironmentName, statusCode: 409);
        }
        return rc;
    });
}
app.Run();

public class FoundByIdException : Exception { public FoundByIdException(string message) : base($"Found by Id: {message}") { } };
public class SaveException : Exception { public SaveException(string message) : base($"SaveChanges error: {message}") { } };
public class AddCelebrityException : Exception { public AddCelebrityException(string message) : base($"AddCelebrityException error: {message}") { } };
public class DeleteCelebrityException : Exception { public DeleteCelebrityException(string message) : base($"DeleteCelebrityException error: {message}") { } };

public static class Validation
{
    public class SurnameFilter : IEndpointFilter
    {
        public static IRepository repository;
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {

            var celebrity = context.GetArgument<Celebrity>(0);
            if (celebrity == null)
                throw new SaveException("Celebrity is NULL");
            if (celebrity.Surname == null || celebrity.Surname.Length < 2) throw new AddCelebrityException("WRONG surname");
            var temp = new Repository(Repository.DirectoryPath);
            var gg = temp.GetAllCelebrities();
            if (gg.Select(x => x.Surname).Contains(celebrity.Surname))
                throw new AddCelebrityException("Surname is already taken");
            return await next(context);
        }
    }
    public class PhotoExistFilter : IEndpointFilter
    {
        public static IRepository repository;
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var celebrity = context.GetArgument<Celebrity>(0);
            if (!File.Exists(Path.Combine(Repository.DirectoryPath, celebrity.PhotoPath)))
                context.HttpContext.Response.Headers.Add("X-Celebrity", "NotFound");
            return await next(context);
        }
    }
    public class PutFilter : IEndpointFilter
    {
        public static IRepository repository;
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var id = context.GetArgument<int>(0);
            var celebrity = context.GetArgument<Celebrity>(1);

            if (!repository.GetAllCelebrities().Select(x => x.Id).Contains(id))
                throw new AddCelebrityException("Id is not in list");
            return await next(context);
        }
    }
    public class DeleteFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var id = context.GetArgument<int>(0);
            var temp = new Repository(Repository.DirectoryPath);
            var gg = temp.GetAllCelebrities();
            if (!gg.Select(x => x.Id).Contains(id))
                throw new AddCelebrityException("Id is not in list");
            return await next(context);
        }
    }

}
