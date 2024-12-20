using ConferenceBackend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавление строки подключения из конфигурации
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Регистрация DbContext с использованием строки подключения
builder.Services.AddDbContext<ConferenceDbContext>(options =>
    options.UseSqlServer(connectionString)); // Или другой провайдер базы данных

// Добавление сервисов для контроллеров
builder.Services.AddControllers();

// Настройка CORS: разрешаем запросы с localhost:5044
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder
            .WithOrigins("http://localhost:5044") // Фронтенд URL
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Настройка маршрутов и использования контроллеров
app.UseRouting();

// Применение политики CORS
app.UseCors("AllowFrontend");

app.MapControllers(); // Это добавляет поддержку маршрутов для контроллеров

app.Run();
