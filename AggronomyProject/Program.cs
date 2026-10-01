using AggronomyProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de la Base de Datos (MySQL)
var connectionString = builder.Configuration.GetConnectionString("MySQL")
    ?? throw new InvalidOperationException("Connection string 'MySQL' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// 2. Configuración de Identity (Lo mantenemos por si manejas usuarios/autenticación)
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 3. CONFIGURACIÓN DE CORS (Vital para conectar con React)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // El puerto donde corre tu Vite/React
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); 
        });
});

// 4. Cambiado de AddControllersWithViews a AddControllers (para que responda con JSON)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
app.UseRouting();

// 5. ACTIVAR CORS (Debe ir obligatoriamente después de UseRouting y antes de UseAuthorization)
app.UseCors("AllowReactApp");

app.UseAuthorization();

// 6. Mapeo exclusivo para Endpoints de API (Adiós a las vistas MVC tradicionales)
app.MapControllers();

// Si estás usando las páginas de Razor por defecto para el login de Identity, déjalo activo:
app.MapRazorPages();

app.Run();