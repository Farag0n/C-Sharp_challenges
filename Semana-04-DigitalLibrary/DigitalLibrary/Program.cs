// Program.cs
using DigitalLibrary.Infraestructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------
// Cargar la cadena de conexión desde appsettings.json
// ------------------------------------------------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ------------------------------------------------------------
// Registrar AppDbContext usando MySQL
// - No se cambió la estructura de AppDbContext (la dejamos igual)
// - ServerVersion.AutoDetect hará match con la versión de MySQL
// ------------------------------------------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Registrar MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ------------------------------------------------------------
// Pipeline básico (middleware)
// ------------------------------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta por defecto: abrimos la app en User/Index (tu requerimiento)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}"
);

app.Run();