using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services;
using Backend.Domain.Service.Services.Interfaces;
using Backend.Infra.EntityLibrary.Data;
using Backend.Infra.Repository.User;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddControllers();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
});

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICreateUserService, CreateUserService>(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();

app.UseHttpsRedirection();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
