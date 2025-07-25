﻿using JDev.Tuteee.Api.DB;
using JDev.Tuteee.Api.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddDbContext<Context>(ServiceLifetime.Transient);

builder.Services.AddEndpoints();

var app = builder.Build();

var context = app.Services.GetRequiredService<Context>();
await context.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    await context.SeedDevelopmentDataAsync(default);
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
    app.UseCors(cpb =>
    {
        cpb.AllowAnyOrigin();
        cpb.AllowAnyMethod();
        cpb.AllowAnyHeader();
    });
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.Run();