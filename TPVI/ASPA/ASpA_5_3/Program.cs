using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseExceptionHandler("/Error");
//--------------A---------//
app.MapGet("/A/{x:int:max(100)}", (HttpContext context, [FromRoute] int? x) =>
    Results.Ok(new { path = context.Request.Path.Value, x = x }));

app.MapPost("/A/{x:int:max(100)}", (HttpContext context, [FromRoute] int? x) =>
    Results.Ok(new { path = context.Request.Path.Value, x = x }));

app.MapPut("/A/{x:int:min(1)}/{y:int:min(1)}", (HttpContext context, [FromRoute] int? x) =>
    Results.Ok(new { path = context.Request.Path.Value, x = x,y=y }));

app.MapDelete("/A/{x:int:min(1)}-{y:int:min(1):max(100)}", (HttpContext context, [FromRoute] int? x, [FromRoute] int y) =>
    Results.Ok(new { path = context.Request.Path.Value, x = x, y = y }));

//--------------B---------//
//--------------C--------//
//--------------D---------//
//--------------E---------//
//--------------F---------//

app.Run();
