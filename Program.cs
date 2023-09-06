using NotifyMeApi.Authentication;
using NotifyMeApi.Models;
using NotifyMeApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

#region dev added
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = ApiKeyAuthOptions.DefaultScheme;
    options.DefaultChallengeScheme = ApiKeyAuthOptions.DefaultScheme;
}).AddApiKeyAuth(builder.Configuration.GetSection("Authentication").Bind);

builder.Services.AddSingleton<INotificationService, NotificationHubService>();

builder.Services.AddOptions<NotificationHubOptions>()
    .Configure(builder.Configuration.GetSection("NotificationHub").Bind)
    .ValidateDataAnnotations();
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region dev added
app.UseAuthentication();
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();

