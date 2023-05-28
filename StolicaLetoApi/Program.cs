using StolicaLetoApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GovnoDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=govnoDB;Username=postgres;Password=vagina21519687"));

builder.Services.AddCoreAdmin();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.UseRouting();

app.UseCoreAdminCustomUrl("adminpanel");

app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();
