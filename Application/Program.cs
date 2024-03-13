using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Infra.Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Repository;
using Service.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Application.Models.Request.User;
using Application.Models.Response.User;
using Application.Models.Response.Produto;
using Application.Models.Request.Log;
using Application.Models.Response.Log;
using Application.Models.Request.Produto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SqlServerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<IBaseService<User>, BaseService<User>>();

builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();
builder.Services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();

builder.Services.AddControllers();
builder.Services.AddSingleton(new MapperConfiguration(config =>
{
    config.CreateMap<CreateUserRequest, User>();
    config.CreateMap<UpdateUserRequest, User>();
    config.CreateMap<User, UserResponse>();

    config.CreateMap<CreateLogRequest, Log>();
    config.CreateMap<UpdateLogRequest, Log>();
    config.CreateMap<Log, LogResponse>();

    config.CreateMap<CreateProdutoRequest, Produto>();
    config.CreateMap<UpdateProdutoRequest, Produto>();
    config.CreateMap<Produto, ProdutoResponse>();
}).CreateMapper());


builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

var app = builder.Build();
app.UseCors("corsapp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

