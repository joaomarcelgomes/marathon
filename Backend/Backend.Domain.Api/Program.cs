using Backend.Domain.Api.Middlewares;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services;
using Backend.Domain.Service.Services.Competitions;
using Backend.Domain.Service.Services.Competitions.Interfaces;
using Backend.Domain.Service.Services.Teams;
using Backend.Domain.Service.Services.Teams.Interfaces;
using Backend.Domain.Service.Services.Users;
using Backend.Domain.Service.Services.Users.Interfaces;
using Backend.Infra.EntityLibrary.Data;
using Backend.Infra.Repository.Competition;
using Backend.Infra.Repository.Team;
using Backend.Infra.Repository.User;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

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
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(["application/json"]);
});

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ICompetitionRepository, CompetitionRepository>();

builder.Services.AddScoped<ICreateUserService, CreateUserService>();
builder.Services.AddScoped<ILoginUserService, LoginUserService>();

builder.Services.AddScoped<ISearchTeamService, SearchTeamService>();
builder.Services.AddScoped<ICreateTeamService, CreateTeamService>();
builder.Services.AddScoped<IEditTeamService, EditTeamService>(); 
builder.Services.AddScoped<IRemoveTeamService, RemoveTeamService>();
builder.Services.AddScoped<IReturnUserService, ReturnUserService>();
builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();
builder.Services.AddScoped<IUpdateUserService, UpdateUserService>();

builder.Services.AddScoped<ICreateCompetitionService, CreateCompetitionService>();
builder.Services.AddScoped<IEditCompetitionService, EditCompetitionService>();
builder.Services.AddScoped<IDeleteCompetitionService, DeleteCompetitionService>();

var app = builder.Build();

app.UseMiddleware<TokenValidationMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
