using AggronomyProject.Data;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 0. Puerto: Railway define la variable PORT. En tu PC no existe y se usan los de launchSettings.
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

// 1. Cabeceras del proxy de Railway (el HTTPS termina en el proxy, no en tu app)
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();   // si lo marca obsoleto, usa KnownIPNetworks
    options.KnownProxies.Clear();
});

// 2. Base de datos (MySQL)
var connectionString = builder.Configuration.GetConnectionString("MySQL")
    ?? throw new InvalidOperationException("Connection string 'MySQL' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// 3. Identity (solo como infraestructura de cookies/autenticación)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = false)   // true exige confirmar por correo
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;
});

// 4. MVC con vistas
builder.Services.AddControllersWithViews(options =>
{
    // Evita que las propiedades de navegación sean "Required" implícitas
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

var app = builder.Build();

// Debe ir primero para que el resto del pipeline vea el esquema HTTPS real
app.UseForwardedHeaders();

// 5. Crear/actualizar las tablas al arrancar (necesita carpeta Migrations).
//    Si creaste la base con un script SQL, borra este bloque.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();