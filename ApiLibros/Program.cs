using Microsoft.EntityFrameworkCore;
using MiApiSQLite.Data; // <-- importa tu carpeta Data (donde está BookContext)

var builder = WebApplication.CreateBuilder(args);

// 🔹 Registramos los controladores
builder.Services.AddControllers();

// 🔹 Configuramos el DbContext con SQLite
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Swagger (para probar la API desde el navegador)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Activamos Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); // <-- importante: activa los controladores (BooksController, etc.)

app.Run();