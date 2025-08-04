var builder = WebApplication.CreateBuilder(args);

// CORS ayarlarını ekle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:30081")  // Frontend'in çalıştığı adres
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// CORS middleware'i kullan
app.UseCors("AllowFrontend");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// connectionString = "server=db;port=3306;database=ziraatdb;user=root;password=0000;";

app.MapGet("/", () => "Hello Ziraat team from Melike!");
app.Run("http://0.0.0.0:30082");