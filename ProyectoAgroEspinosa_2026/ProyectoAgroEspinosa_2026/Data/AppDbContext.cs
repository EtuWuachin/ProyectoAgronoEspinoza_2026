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
        public DbSet<L_Inventory> Inventarios { get; set; }
        public DbSet<M_Paymentmethod> MetodosPagos { get; set; }
        public DbSet<F_Paid> Pagos { get; set; }
        public DbSet<E_Final_Product> ProductosFinales { get; set; }
        public DbSet<E_Initial_Product> ProductosIniciales { get; set; }
        public DbSet<P_Supplier> Proveedores { get; set; }
        public DbSet<R_Resource> Recursos { get; set; }
        public DbSet<A_Resource_Adm> RecursosAdministradores { get; set; }
        public DbSet<G_Report> Reportes { get; set; }
        public DbSet<K_Worker> Trabajadores { get; set; }
        public DbSet<M_UserTT> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Inventario
            modelBuilder.Entity<L_Inventory>()
                .HasOne(i => i.productoinicial)
                .WithMany(p => p.inventario)
                .HasForeignKey(i => i.idProductoInicial);

            modelBuilder.Entity<L_Inventory>()
                .HasOne(i => i.productofinal)
                .WithMany(p => p.inventario)
                .HasForeignKey(i => i.idProductoFinal);

            // Recurso - Proveedor
            modelBuilder.Entity<R_Resource>()
                .HasOne(r => r.proveedor)
                .WithMany(p => p.recurso)
                .HasForeignKey(r => r.idProveedor);

            // RecursosAdministrador - Recurso
            modelBuilder.Entity<A_Resource_Adm>()
                .HasOne(ra => ra.recurso)
                .WithMany(r => r.recursosadministrador)
                .HasForeignKey(ra => ra.idRecurso);

            // Pago - MetodoPago (un pago tiene un método, un método tiene muchos pagos)
            modelBuilder.Entity<F_Paid>()
                .HasOne(p => p.metodopago)
                .WithMany(mp => mp.pagos)
                .HasForeignKey(p => p.IdMetodoPago);

            // Administracion (tabla central)
            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.reporte)
                .WithMany(r => r.administracion)
                .HasForeignKey(a => a.idReporte);

            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.trabajador)
                .WithMany(t => t.administracion)
                .HasForeignKey(a => a.idTrabajador);

            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.inventario)
                .WithMany(i => i.administracion)
                .HasForeignKey(a => a.idInventario);

            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.pago)
                .WithMany(p => p.administracion)
                .HasForeignKey(a => a.IdPago);

            modelBuilder.Entity<T_AdmTT>()
                .HasOne(a => a.recursosadministrador)
                .WithMany()
                .HasForeignKey(a => a.idRecursosAdministrador);

            // Usuario - Rol
            modelBuilder.Entity<M_UserTT>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuario)
                .HasForeignKey(u => u.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- SEEDS ----------
            modelBuilder.Entity<U_RoleCC>().HasData(
                new U_RoleCC { IdRol = 1, NombreRol = "Administrador", Estado = true },
                new U_RoleCC { IdRol = 2, NombreRol = "Trabajador", Estado = true }
            );

            modelBuilder.Entity<G_Report>().HasData(
                new G_Report
                {
                    idReporte = 1,
                    titulo = "Reporte Inicial",
                    tiporeporte = "General",
                    fechageneracion = new DateTime(2025, 1, 1),
                    contenido = "Reporte generado por el sistema",
                    generadopor = "Sistema",
                    estado = true
                });

            modelBuilder.Entity<M_Paymentmethod>().HasData(
                new M_Paymentmethod
                {
                    IdMetodoPago = 1,
                    nombre = "Efectivo",
                    descripcion = "Pago en efectivo",
                    estado = true
                });

            modelBuilder.Entity<F_Paid>().HasData(
                new F_Paid
                {
                    IdPago = 1,
                    monto = 0.00m,
                    fechapago = new DateTime(2025, 1, 1),
                    concepto = "Pago inicial",
                    comprobante = "COMP-0001",
                    estado = true,
                    IdMetodoPago = 1
                });

            modelBuilder.Entity<E_Initial_Product>().HasData(
                new E_Initial_Product
                {
                    idProductoInicial = 1,
                    nombre = "Producto Inicial Demo",
                    descripcion = "Producto de prueba",
                    cantidadinicial = 0,
                    unidadmedida = "kg",
                    costounitario = 0.0f,
                    fechaingreso = new DateTime(2025, 1, 1),
                    proveedororigen = "Demo",
                    estado = true
                });

            modelBuilder.Entity<E_Final_Product>().HasData(
                new E_Final_Product
                {
                    idProductoFinal = 1,
                    nombre = "Producto Final Demo",
                    descripcion = "Producto de prueba",
                    cantidadproducida = 0,
                    unidadmedida = "kg",
                    precioventa = 0.0f,
                    estado = true
                });

            modelBuilder.Entity<L_Inventory>().HasData(
                new L_Inventory
                {
                    idInventario = 1,
                    nombre = "Inventario General",
                    descripcion = "Inventario inicial del sistema",
                    stockactual = 0,
                    stockminimo = 0,
                    unidadmedida = "kg",
                    fechaactualizacion = new DateTime(2025, 1, 1),
                    estado = true,
                    idProductoInicial = 1,
                    idProductoFinal = 1
                });

            modelBuilder.Entity<P_Supplier>().HasData(
                new P_Supplier
                {
                    idProveedor = 1,
                    nombre = "Proveedor Demo",
                    ruc = "00000000000",
                    direccion = "Sin dirección",
                    telefono = "000000000",
                    email = "proveedor@demo.com",
                    estado = true
                });

            modelBuilder.Entity<R_Resource>().HasData(
                new R_Resource
                {
                    idRecurso = 1,
                    fechaingreso = new DateTime(2025, 1, 1),
                    cantidadrecibida = 0,
                    unidadmedida = "kg",
                    tiporecurso = "General",
                    costorecurso = 0.0f,
                    estado = true,
                    idProveedor = 1
                });

            modelBuilder.Entity<A_Resource_Adm>().HasData(
                new A_Resource_Adm
                {
                    idRecursosAdministrador = 1,
                    fecharecepcion = new DateTime(2025, 1, 1),
                    cantidadrecibida = 0,
                    observaciones = "Registro inicial",
                    estado = true,
                    idRecurso = 1
                });

            modelBuilder.Entity<K_Worker>().HasData(
                new K_Worker
                {
                    idTrabajador = 1,
                    nombres = "Trabajador",
                    apellidos = "Demo",
                    dni = "00000000",
                    cargo = "General",
                    telefono = "000000000",
                    email = "trabajador@agronomia.com",
                    fechacontrato = new DateTime(2025, 1, 1),
                    estado = true
                });

            modelBuilder.Entity<T_AdmTT>().HasData(
                new T_AdmTT
                {
                    IdAdministracion = 1,
                    nombre = "Administración General",
                    descripcion = "Registro inicial del sistema",
                    fecharegistro = new DateTime(2025, 1, 1),
                    responsable = "Sistema",
                    estado = true,
                    idReporte = 1,
                    idTrabajador = 1,
                    idInventario = 1,
                    IdPago = 1,
                    idRecursosAdministrador = 1
                });

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