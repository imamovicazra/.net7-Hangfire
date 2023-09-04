using Hangfire;
using Hangfire.API.Extensions;
using Hangfire.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HangfireContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DBConnection"));
});
builder.Services.AddHangfireServer();


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
app.ConfigureHangfireDashboard(builder, builder.Configuration);

app.Run();
