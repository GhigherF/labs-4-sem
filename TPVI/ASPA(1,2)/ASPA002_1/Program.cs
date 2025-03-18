var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseWelcomePage("/");

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/aspcorenet", () => "Hello World!");

app.Run();
