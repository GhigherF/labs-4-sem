using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;


class Test
{
    class Answer<T>
    {
        public T? x { get; set; } = default(T?);
        public T? y { get; set; } = default(T?);
        public string? message { get; set; } = null;
    }
    public static string OK = "OK", NOK = "NOK";
    HttpClient client = new HttpClient();
    public async Task ExecuteGET<T>(string path, Func<T?, T?, int, string> result)
    {
        await resultPRINT<T>("GET", path, await this.client.GetAsync(path), result);
    }
    public async Task ExecutePOST<T>(string path, Func<T?, T?, int, string> result)
    {
        await resultPRINT<T>("POST", path, await this.client.PostAsync(path, null), result);
    }
    public async Task ExecutePUT<T>(string path, Func<T?, T?, int, string> result)
    {
        await resultPRINT<T>("PUT", path, await this.client.PutAsync(path, null), result);
    }
    public async Task ExecuteDELETE<T>(string path, Func<T?, T?, int, string> result)
    {
        await resultPRINT<T>("DELETE", path, await this.client.DeleteAsync(path), result);
    }
    async Task resultPRINT<T>(string method, string path, HttpResponseMessage rm, Func<T?, T?, int, string> result)
    {
        int status = (int)rm.StatusCode;
        try
        {
            Answer<T>? answer = await rm.Content.ReadFromJsonAsync<Answer<T>>() ?? default(Answer<T>);
            string r = result(default(T), default(T), status);
            T? x = default(T), y = default(T);
            if (answer != null) r = result(x = answer.x, y = answer.y, status);
            Console.WriteLine($" {r}: {method}  {path}, status = {status}, x = {x}, y = {y}, m = {answer?.message}");
        }
        catch (JsonException ex)
        {
            string r = result(default(T), default(T), status);
            Console.WriteLine($" {r}: {method}  {path}, status = {status}, x = {null}, y = {null}, m = {ex.Message}");
        }
    }
}


    partial class Program
{
    public static async Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.MapGet("/", () => "Hello World!");
        app.UseExceptionHandler("/Error");
        //--------------A---------//
        app.MapGet("/A/{x:int:max(100)}", (HttpContext context, [FromRoute] int? x) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x }));

        app.MapPost("/A/{x:int:max(100)}", (HttpContext context, [FromRoute] int? x) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x }));

        app.MapPut("/A/{x:int:min(1)}/{y:int:min(1)}", (HttpContext context, [FromRoute] int? x, [FromRoute] int y) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x, y = y }));

        app.MapDelete("/A/{x:int:min(1)}-{y:int:min(1):max(100)}", (HttpContext context, [FromRoute] int? x, [FromRoute] int y) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x, y = y }));

        //--------------B---------//
        app.MapGet("/B/{x:float}", (HttpContext context, [FromRoute] float? x) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x }));

        app.MapPost("/B/{x:float}/{y:float}", (HttpContext context, [FromRoute] float? x, [FromRoute] float y) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x, y = y }));

        app.MapDelete("/B/{x:float}-{y:float}", (HttpContext context, [FromRoute] float? x, [FromRoute] float y) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x, y = y }));

        //--------------C--------//
        app.MapGet("/C/{x:bool}", (HttpContext context, [FromRoute] bool? x) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x }));

        app.MapPost("/C/{x:bool},{y:bool}", (HttpContext context, [FromRoute] bool? x, [FromRoute] bool y) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x, y = y }));
        //--------------D---------//
        app.MapGet("/D/{x:DateTime}", (HttpContext context, [FromRoute] DateTime? x) =>
        Results.Ok(new { path = context.Request.Path.Value, x = x }));

        app.MapPost("/D/{x:DateTime}|{y:DateTime}", (HttpContext context, [FromRoute] DateTime? x, [FromRoute] DateTime y) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x, y = y }));
        //--------------E---------//
        app.MapGet("/E/12-{x:required}", (HttpContext context, [FromRoute] string x) =>
        Results.Ok(new { path = context.Request.Path.Value, x = x }));
        app.MapPut("/E/{x:alpha:minlength(2):maxlength(12)}", (HttpContext context, [FromRoute] string x) =>
            Results.Ok(new { path = context.Request.Path.Value, x = x }));
        //--------------F---------//
        app.MapPut("/F/{x:regex(^[a-zA-Z0-9!#$%^&*]+@.+\\.by$)}", (HttpContext context, string x) =>
        {
            return Results.Ok(new { path = context.Request.Path.Value, x = x });
        });
        var serverTask = Task.Run(() => app.RunAsync());
  

        Test test = new Test();

        Console.WriteLine("--/A-----------------------------------------------------------------------");

        await test.ExecuteGET<int?>("https://localhost:228/A/3", (int? x, int? y, int status) =>
          (x == 3 && y == null && status == 200) ? Test.OK : Test.NOK);

        await test.ExecuteGET<int?>("https://localhost:228/A/-3", (int? x, int? y, int status) =>
          (x == -3 && y == null && status == 200) ? Test.OK : Test.NOK);

        await test.ExecuteGET<int?>("https://localhost:228/A/118", (int? x, int? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);

        await test.ExecutePOST<int?>("https://localhost:228/A/5", (int? x, int? y, int status) =>
          (x == 5 && y == null && status == 200) ? Test.OK : Test.NOK);

        await test.ExecutePOST<int?>("https://localhost:228/A/-5", (int? x, int? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);

        await test.ExecutePOST<int?>("https://localhost:228/A/118", (int? x, int? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);

        await test.ExecutePUT<int?>("https://localhost:228/A/2/3", (int? x, int? y, int status) =>
          (x == 2 && y == 3 && status == 200) ? Test.OK : Test.NOK);

        await test.ExecutePUT<int?>("https://localhost:228/A/0/3", (int? x, int? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);

        await test.ExecutePUT<int?>("https://localhost:228/A/25-3", (int? x, int? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);

        await test.ExecutePUT<int?>("https://localhost:228/A/0-3", (int? x, int? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);

        await test.ExecuteDELETE<int?>("https://localhost:228/A/1-99", (int? x, int? y, int status) =>
          (x == 1 && y == 99 && status == 200) ? Test.OK : Test.NOK);

        await test.ExecuteDELETE<int?>("https://localhost:228/A/99-1", (int? x, int? y, int status) =>
          (x == 99 && y == 1 && status == 200) ? Test.OK : Test.NOK);

        await test.ExecuteDELETE<int?>("https://localhost:228/A/-1-25", (int? x, int? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);

        await test.ExecuteDELETE<int?>("https://localhost:228/A/-1--25", (int? x, int? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);

        await test.ExecuteDELETE<int?>("https://localhost:228/A/25-101", (int? x, int? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);


        Console.WriteLine("-- /B--------------------------------------------------------------------------");
        await test.ExecuteGET<float?>("https://localhost:228/B/2.5", (float? x, float? y, int status) =>
          (x == 2.5 && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteGET<float?>("https://localhost:228/B/2", (float? x, float? y, int status) =>
          (x == 2.0 && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteGET<float?>("https://localhost:228/B/2X", (float? x, float? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecutePOST<float?>("https://localhost:228/B/2.5/3.2", (float? x, float? y, int status) =>
          (x == 2.5 && y == 3.2 && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteDELETE<float?>("https://localhost:228/B/2.5-3.2", (float? x, float? y, int status) =>
          (x == 2.5 && y == 3.2 && status == 200) ? Test.OK : Test.NOK);


        Console.WriteLine("-- /C");
        await test.ExecuteGET<bool?>("https://localhost:228/C/2.5", (bool? x, bool? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecuteGET<bool?>("https://localhost:228/C/true", (bool? x, bool? y, int status) =>
          (x == true && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecutePOST<bool?>("https://localhost:228/C/true,false", (bool? x, bool? y, int status) =>
          (x == true && y == false && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteDELETE<bool?>("https://localhost:228//C/true,false", (bool? x, bool? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);



        Console.WriteLine("-- /D------------------------------------------------------------------------------");
        await test.ExecuteGET<DateTime?>("https://localhost:228/D/2025-02-25", (DateTime? x, DateTime? y, int status) =>
          (x == new DateTime(2025, 02, 25) && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteGET<DateTime?>("https://localhost:228/D/2025-02-29", (DateTime? x, DateTime? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecuteGET<DateTime?>("https://localhost:228/D/2024-02-29", (DateTime? x, DateTime? y, int status) =>
          (x == new DateTime(2024, 02, 29) && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteGET<DateTime?>("https://localhost:228/D/2025-02-25T19:25", (DateTime? x, DateTime? y, int status) =>
          (x == new DateTime(2025, 02, 25, 19, 25, 0) && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecutePOST<DateTime?>("https://localhost:228/D/2025-02-25|2025-03-25", (DateTime? x, DateTime? y, int status) =>
          (x == new DateTime(2025, 02, 25) && y == new DateTime(2025, 03, 25) && status == 200) ? Test.OK : Test.NOK);
        await test.ExecutePUT<DateTime?>("https://localhost:228/D/2025-02-25T19:25", (DateTime? x, DateTime? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);


        Console.WriteLine("-- /E---------------------------------------------------------------------------");
        await test.ExecuteGET<string?>("https://localhost:228/E/12-bis", (string? x, string? y, int status) =>
          (x == "bis" && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteGET<string?>("https://localhost:228/E/11-bis", (string? x, string? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecuteGET<string?>("https://localhost:228/E/12-777", (string? x, string? y, int status) =>
          (x == "777" && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteGET<string?>("https://localhost:228/E/12-", (string? x, string? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecutePUT<string?>("https://localhost:228/E/abcd", (string? x, string? y, int status) =>
          (x == "abcd" && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecutePUT<string?>("https://localhost:228/E/abcd123", (string? x, string? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecutePUT<string?>("https://localhost:228/E/a", (string? x, string? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecutePUT<string?>("https://localhost:228/E/123456", (string? x, string? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecutePUT<string?>("https://localhost:228/E/aabbccddeeffgghh", (string? x, string? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);


        Console.WriteLine("-- /F-----------------------------------------------------------------------------");
        await test.ExecuteGET<string?>("https://localhost:228/F/snw@belstu.by", (string? x, string? y, int status) =>
          (x == "snw@belstu.by" && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteGET<string?>("https://localhost:228/F/xxxx@yyyy.by", (string? x, string? y, int status) =>
          (x == "xxxx@yyyy.by" && y == null && status == 200) ? Test.OK : Test.NOK);
        await test.ExecuteGET<string?>("https://localhost:228/F/xxxx@yyyy.ru", (string? x, string? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecuteGET<string?>("https://localhost:228/F/xxxxyyyy.by", (string? x, string? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await test.ExecuteGET<string?>("https://localhost:228/F/xxxx@yyyy", (string? x, string? y, int status) =>
          (x == null && y == null && status == 404) ? Test.OK : Test.NOK);
        await serverTask;
    }

}

