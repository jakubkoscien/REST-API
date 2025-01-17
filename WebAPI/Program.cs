using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Respositories;
using WebAPI.Installers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//  {
//      c.EnableAnnotations();
//  });
//builder.Services.AddScoped<IPostRepository, PostRepository>();
//builder.Services.AddScoped<IPostService, PostService>();
//builder.Services.AddSingleton(AutoMapperConfig.Initialize());

builder.Services.InstallServicesInAssembly(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
