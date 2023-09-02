using Microsoft.Extensions.Options;
using MongoDB.Driver;
using tg_server.models;
using tg_server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<tgCommentsDatabaseSetting>(builder.Configuration.GetSection(nameof(tgCommentsDatabaseSetting)));

builder.Services.AddSingleton<ItgCommentsDatabaseSettings>(sp => sp.GetRequiredService<IOptions<tgCommentsDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("CommentsDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ICommentService, CommentService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
app.UseCors("corsapp");
// Configure the CORS policy with specific origins and other settings.
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:8080") // Add the allowed origins here
           .AllowAnyMethod()
           .AllowAnyHeader();
});

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
