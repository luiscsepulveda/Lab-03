﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ReadDB.Data.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DataAccess>();

// Registrar DataAccess como un servicio
builder.Services.AddScoped<DataAccess>();

// Configurar el contexto de la base de datos si es necesario
// builder.Services.AddDbContext<YourDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
