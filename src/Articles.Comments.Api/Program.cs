using Articles.Comments.Api.DataAdapters;
using Articles.Comments.Api.InfraStructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommentDBContext>(opt => opt.UseSqlServer("Data source=IN-1360C54;Initial catalog=commentdb;Integrated Security=true;TrustServerCertificate=True;"));
builder.Services.AddAutoMapper(typeof(ConfigMap));
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//*** Code to update database
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<CommentDBContext>();
    dataContext.Database.Migrate();
}

app.Run();
