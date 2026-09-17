using Microsoft.EntityFrameworkCore;
using ProyectoAgroEspinosa_2026.Models;

namespace ProyectoAgroEspinosa_2026.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<T_AdmTT> Administraciones { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<MetodoPago> MetodosPagos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<ProductoFinal> ProductosFinales { get; set; }
        public DbSet<ProductoInicial> ProductosIniciales { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<R_Resource> Recursos { get; set; }
        public DbSet<A_Resource_Adm> RecursosAdministradores { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<M_UserTT> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relaciones de inventario
            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.productoinicial)
                .WithMany(p => p.inventario)
                .HasForeignKey(i => i.id_producto_inicial);

            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.productofinal)
                .WithMany(p => p.inventario)
                .HasForeignKey(i => i.id_producto_final);

            // Relación recurso - proveedor
            modelBuilder.Entity<R_Resource>()
                .HasOne(r => r.proveedor)
                .WithMany(p => p.recurso)
                .HasForeignKey(r => r.id_proveedor);

            // Relación recursos_administrador - recurso
            modelBuilder.Entity<A_Resource_Adm>()
                .HasOne(ra => ra.recurso)
                .WithMany(r => r.recursosadministrador)
                .HasForeignKey(ra => ra.id_recurso);

            // Relación MetodoPago - Pago
            modelBuilder.Entity<MetodoPago>()
                .HasOne(mp => mp.pago)
                .WithMany(p => p.metodopago)
                .HasForeignKey(mp => mp.id_pago);

            // Relaciones de Administracion (Tabla Central)
            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.reporte)
                .WithMany(r => r.administracion)
                .HasForeignKey(a => a.id_reporte);

            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.trabajador)
                .WithMany(t => t.administracion)
                .HasForeignKey(a => a.id_trabajador);

            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.inventario)
                .WithMany(i => i.administracion)
                .HasForeignKey(a => a.id_inventario);

            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.metodopago)
                .WithMany(mp => mp.administracion)
                .HasForeignKey(a => a.id_metodo_pago);

            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.recursosadministrador)
                .WithMany()
                .HasForeignKey(a => a.id_recursos_administrador);

            // Relación Usuario - Rol
            modelBuilder.Entity<M_UserTT>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.IdRol)
                .OnDelete(DeleteBehavior.Restrict);
            // Seed Roles
            modelBuilder.Entity<U_RoleCC>().HasData(
                new U_RoleCC { IdRol = 1, NombreRol = "Administrador", Estado = true },
                new U_RoleCC { IdRol = 2, NombreRol = "Trabajador", Estado = true }
            );
            // Reporte
            modelBuilder.Entity<Reporte>().HasData(
                new Reporte
                {
                    id_reporte = 1,
                    titulo = "Reporte Inicial",
                    tipo_reporte = "General",
                    fecha_generacion = new DateTime(2025, 1, 1),
                    contenido = "Reporte generado por el sistema",
                    generado_por = "Sistema",
                    estado = true
                });
            // Pago 
            modelBuilder.Entity<Pago>().HasData(
                new Pago
                {
                    IdPago = 1,
                    monto = 0.00m,
                    fecha_pago = new DateTime(2025, 1, 1),
                    concepto = "Pago inicial",
                    comprobante = "COMP-0001",
                    estado = true
                });
            // MetodoPago
            modelBuilder.Entity<MetodoPago>().HasData(
                new MetodoPago
                {
                    IdMetodoPago = 1,
                    nombre = "Efectivo",
                    descripcion = "Pago en efectivo",
                    estado = true,
                    id_pago = 1
                });
            // ProductoInicial 
            modelBuilder.Entity<ProductoInicial>().HasData(
                new ProductoInicial
                {
                    id_producto_inicial = 1,
                    nombre = "Producto Inicial Demo",
                    descripcion = "Producto de prueba",
                    cantidad_inicial = 0,
                    unidad_medida = "kg",
                    costo_unitario = 0.0f,
                    fecha_ingreso = new DateTime(2025, 1, 1),
                    proveedor_origen = "Demo",
                    estado = true
                });
            // ProductoFinal
            modelBuilder.Entity<ProductoFinal>().HasData(
                new ProductoFinal
                {
                    id_producto_final = 1,
                    nombre = "Producto Final Demo",
                    descripcion = "Producto de prueba",
                    cantidad_producida = 0,
                    unidad_medida = "kg",
                    precio_venta = 0.0f,
                    estado = true
                });
            // 8. Inventario
            modelBuilder.Entity<Inventario>().HasData(
                new Inventario
                {
                    id_iventario = 1,
                    nombre = "Inventario General",
                    descripcion = "Inventario inicial del sistema",
                    stock_actual = 0,
                    stock_minimo = 0,
                    unidad_medida = "kg",
                    fecha_actualizacion = new DateTime(2025, 1, 1),
                    estado = true,
                    id_producto_inicial = 1,
                    id_producto_final = 1
                }
            );
            // Proveedor
            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor
                {
                    id_proveedor = 1,
                    nombre = "Proveedor Demo",
                    ruc = "00000000000",
                    direccion = "Sin dirección",
                    telefono = "000000000",
                    email = "proveedor@demo.com",
                    estado = true
                }
            );
            // Recurso 
            modelBuilder.Entity<R_Resource>().HasData(
                new R_Resource
                {
                    id_recurso = 1,
                    fecha_ingreso = new DateTime(2025, 1, 1),
                    cantidad_recibida = 0,
                    unidad_medida = "kg",
                    tipo_recurso = "General",
                    costo_recurso = 0.0f,
                    estado = true,
                    id_proveedor = 1
                }
            );
            // RecursosAdministrador
            modelBuilder.Entity<A_Resource_Adm>().HasData(
                new A_Resource_Adm
                {
                    id_recursos_administrador = 1,
                    fecha_recepcion = new DateTime(2025, 1, 1),
                    cantidad_recibida = 0,
                    observaciones = "Registro inicial",
                    estado = true,
                    id_recurso = 1
                }
            );
            modelBuilder.Entity<Trabajador>().HasData(
            new Trabajador
            {
                id_trabajador = 1,
                nombres = "Trabajador",
                apellidos = "Demo",
                dni = "00000000",
                cargo = "General",
                telefono = "000000000",
                email = "trabajador@agronomia.com",
                fecha_contrato = new DateTime(2025, 1, 1),
                estado = true
            });
            modelBuilder.Entity<T_AdmTT>().HasData(
                new T_AdmTT
                {
                    IdAdministracion = 1,
                    nombre = "Administración General",
                    descripcion = "Registro inicial del sistema",
                    fecha_registro = new DateTime(2025, 1, 1),
                    responsable = "Sistema",
                    estado = true,
                    id_reporte = 1,
                    id_trabajador = 1,
                    id_inventario = 1,
                    id_metodo_pago = 1,
                    id_recursos_administrador = 1
                });

            // Seed Usuarios
            modelBuilder.Entity<M_UserTT>().HasData(
                new M_UserTT
                {
                    IdUsuario = 1,
                    NombreUsuario = "admin",
                    CorreoElectronico = "admin@agronomia.com",
                    Contrasena = "Admin123",
                    Estado = true,
                    IdRol = 1
                },
                new M_UserTT
                {
                    IdUsuario = 2,
                    NombreUsuario = "trabajador",
                    CorreoElectronico = "trabajador@agronomia.com",
                    Contrasena = "Trab123",
                    Estado = true,
                    IdRol = 2
                });

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
