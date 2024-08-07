using BookStore.API.Contracts;
using BookStore.API.Repositories;
using BookStore.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repositories
builder.Services.AddSingleton<IBookStoreRepository, BookStoreRepository>(_ => new BookStoreRepository("Server=localhost;Database=book_store_db;Trusted_Connection=True;"));
//services
builder.Services.AddSingleton<IBookStoreService, BookStoreService>();

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
