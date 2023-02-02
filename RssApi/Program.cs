using FluentValidation.AspNetCore;
using RssApi.DAL.Configuration;
using RssApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.Key));

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.ConfigureCors();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureSwagger();

builder.Services.AddIdentity();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();