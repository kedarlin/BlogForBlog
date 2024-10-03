using BlogForBlog.Data;
using BlogForBlog.Repositories;
using BlogForBlog.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure the database connection string (MariaDB connection in this case)
builder.Services.AddDbContext<BloggingContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(10, 4, 32))  // Adjust version accordingly
    )
);

// Add repositories and services to dependency injection container
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();

// Add controllers to the DI container
builder.Services.AddControllers();

// Enable Swagger for API documentation (optional, can remove if not needed)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();