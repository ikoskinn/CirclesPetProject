using DotByDot.Data;
using DotByDot.Data.Mapper;
using DotByDot.Repository;
using DotByDot.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
        .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("https://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddTransient<ICircleRepository, CircleRepository>();
builder.Services.AddTransient<ICircleService, CircleService>();


builder.Services.AddDbContext<DotByDotContext>(options => options.UseSqlServer(builder.Configuration.GetSection("MSSQL").GetValue("ConnectionString", "")));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");
//app.UseCors(builder => builder.AllowAnyHeader().AllowCredentials());

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
