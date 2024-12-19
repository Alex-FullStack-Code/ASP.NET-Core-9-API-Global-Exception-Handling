using GlobalExceptionHandling;
using GlobalExceptionHandling.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.UseExceptionHandler(options =>
//{
//    options.Run(async context =>
//    {
//        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//        context.Response.ContentType = "application/json";
//        var exception = context.Features.Get<IExceptionHandlerFeature>();
//        if (exception != null)
//        {
//            var message = $"{exception.Error.Message}";
//            await context.Response.WriteAsync(message).ConfigureAwait(false);
//        }
//    });
//});

//app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseExceptionHandler();


app.MapGet("/", () =>
{
    throw new ProductNotFoundException(Guid.NewGuid());
});


app.Run();
