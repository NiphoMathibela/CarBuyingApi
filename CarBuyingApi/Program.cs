using CarBuyingApi.Models;
using CarBuyingApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CarsForSaleDbSettings>(
    builder.Configuration.GetSection("CarsForSaleDatabase"));

builder.Services.AddSingleton<CarService>();

//Added user service
builder.Services.AddSingleton<UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Creating cross origin polic
var  CarPolicy = "CarPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CarPolicy,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
                      });
});
//End of cross origin

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Adding useCors
app.UseCors(CarPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
