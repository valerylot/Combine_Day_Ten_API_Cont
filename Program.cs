using Combine_Day_Ten_API_Cont.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//AddScoped
//We are registering our services within our app making them accessible 
//Whenever we access our ICargoServices Interface, it knows to pass it to our Cargo Services
builder.Services.AddScoped<ICargoServices, CargoServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
