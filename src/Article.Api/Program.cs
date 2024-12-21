using Article.Api.DataAdapters;
using Article.Api.Infrastructure;
using Article.Api.ServicesClients;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ArticleDbContext>(options => options.UseSqlServer("Data source=IN-1360C54;Initial catalog=articledb;Integrated Security=true;TrustServerCertificate=True;"));
builder.Services.AddAutoMapper(typeof(ConfigMap));
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddRefitClient<ICommentsServiceClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7280/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints=> endpoints.MapControllers());

//*** Code to update database
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ArticleDbContext>();
    dataContext.Database.Migrate();
}

app.Run();