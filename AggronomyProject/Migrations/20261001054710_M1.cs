using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AggronomyProject.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    concepto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    comprobante = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductosFinales",
                columns: table => new
                {
                    id_producto_final = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cantidad_producida = table.Column<int>(type: "int", nullable: false),
                    unidad_medida = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    precio_venta = table.Column<float>(type: "float", nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosFinales", x => x.id_producto_final);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductosIniciales",
                columns: table => new
                {
                    id_producto_inicial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cantidad_inicial = table.Column<int>(type: "int", nullable: false),
                    unidad_medida = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    costo_unitario = table.Column<float>(type: "float", nullable: false),
                    fecha_ingreso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    proveedor_origen = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosIniciales", x => x.id_producto_inicial);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    id_proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ruc = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.id_proveedor);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    id_reporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    tipo_reporte = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    fecha_generacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    contenido = table.Column<string>(type: "longtext", nullable: false),
                    generado_por = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.id_reporte);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreRol = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    id_trabajador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombres = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    apellidos = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    dni = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    cargo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    fecha_contrato = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.id_trabajador);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MetodosPagos",
                columns: table => new
                {
                    IdMetodoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_pago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPagos", x => x.IdMetodoPago);
                    table.ForeignKey(
                        name: "FK_MetodosPagos_Pagos_id_pago",
                        column: x => x.id_pago,
                        principalTable: "Pagos",
                        principalColumn: "IdPago",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    id_iventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    stock_actual = table.Column<int>(type: "int", nullable: false),
                    stock_minimo = table.Column<int>(type: "int", nullable: false),
                    unidad_medida = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_producto_inicial = table.Column<int>(type: "int", nullable: false),
                    id_producto_final = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.id_iventario);
                    table.ForeignKey(
                        name: "FK_Inventarios_ProductosFinales_id_producto_final",
                        column: x => x.id_producto_final,
                        principalTable: "ProductosFinales",
                        principalColumn: "id_producto_final",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventarios_ProductosIniciales_id_producto_inicial",
                        column: x => x.id_producto_inicial,
                        principalTable: "ProductosIniciales",
                        principalColumn: "id_producto_inicial",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    id_recurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fecha_ingreso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    cantidad_recibida = table.Column<int>(type: "int", nullable: false),
                    unidad_medida = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    tipo_recurso = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    costo_recurso = table.Column<float>(type: "float", nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_proveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recursos", x => x.id_recurso);
                    table.ForeignKey(
                        name: "FK_Recursos_Proveedores_id_proveedor",
                        column: x => x.id_proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "id_proveedor",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    RolIdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolIdRol",
                        column: x => x.RolIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecursosAdministradores",
                columns: table => new
                {
                    id_recursos_administrador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fecha_recepcion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    cantidad_recibida = table.Column<int>(type: "int", nullable: false),
                    observaciones = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_recurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursosAdministradores", x => x.id_recursos_administrador);
                    table.ForeignKey(
                        name: "FK_RecursosAdministradores_Recursos_id_recurso",
                        column: x => x.id_recurso,
                        principalTable: "Recursos",
                        principalColumn: "id_recurso",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Administraciones",
                columns: table => new
                {
                    IdAdministracion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    responsable = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_reporte = table.Column<int>(type: "int", nullable: false),
                    id_trabajador = table.Column<int>(type: "int", nullable: false),
                    id_inventario = table.Column<int>(type: "int", nullable: false),
                    id_metodo_pago = table.Column<int>(type: "int", nullable: false),
                    id_recursos_administrador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administraciones", x => x.IdAdministracion);
                    table.ForeignKey(
                        name: "FK_Administraciones_Inventarios_id_inventario",
                        column: x => x.id_inventario,
                        principalTable: "Inventarios",
                        principalColumn: "id_iventario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administraciones_MetodosPagos_id_metodo_pago",
                        column: x => x.id_metodo_pago,
                        principalTable: "MetodosPagos",
                        principalColumn: "IdMetodoPago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administraciones_RecursosAdministradores_id_recursos_adminis~",
                        column: x => x.id_recursos_administrador,
                        principalTable: "RecursosAdministradores",
                        principalColumn: "id_recursos_administrador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administraciones_Reportes_id_reporte",
                        column: x => x.id_reporte,
                        principalTable: "Reportes",
                        principalColumn: "id_reporte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administraciones_Trabajadores_id_trabajador",
                        column: x => x.id_trabajador,
                        principalTable: "Trabajadores",
                        principalColumn: "id_trabajador",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "IdPago", "comprobante", "concepto", "estado", "fecha_pago", "monto" },
                values: new object[] { 1, "COMP-0001", "Pago inicial", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.00m });

            migrationBuilder.InsertData(
                table: "ProductosFinales",
                columns: new[] { "id_producto_final", "cantidad_producida", "descripcion", "estado", "nombre", "precio_venta", "unidad_medida" },
                values: new object[] { 1, 0, "Producto de prueba", true, "Producto Final Demo", 0f, "kg" });

            migrationBuilder.InsertData(
                table: "ProductosIniciales",
                columns: new[] { "id_producto_inicial", "cantidad_inicial", "costo_unitario", "descripcion", "estado", "fecha_ingreso", "nombre", "proveedor_origen", "unidad_medida" },
                values: new object[] { 1, 0, 0f, "Producto de prueba", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Producto Inicial Demo", "Demo", "kg" });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "id_proveedor", "direccion", "email", "estado", "nombre", "ruc", "telefono" },
                values: new object[] { 1, "Sin dirección", "proveedor@demo.com", true, "Proveedor Demo", "00000000000", "000000000" });

            migrationBuilder.InsertData(
                table: "Reportes",
                columns: new[] { "id_reporte", "contenido", "estado", "fecha_generacion", "generado_por", "tipo_reporte", "titulo" },
                values: new object[] { 1, "Reporte generado por el sistema", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistema", "General", "Reporte Inicial" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRol", "Estado", "NombreRol" },
                values: new object[,]
                {
                    { 1, true, "Administrador" },
                    { 2, true, "Trabajador" }
                });

            migrationBuilder.InsertData(
                table: "Trabajadores",
                columns: new[] { "id_trabajador", "apellidos", "cargo", "dni", "email", "estado", "fecha_contrato", "nombres", "telefono" },
                values: new object[] { 1, "Demo", "General", "00000000", "trabajador@agronomia.com", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trabajador", "000000000" });

            migrationBuilder.InsertData(
                table: "Inventarios",
                columns: new[] { "id_iventario", "descripcion", "estado", "fecha_actualizacion", "id_producto_final", "id_producto_inicial", "nombre", "stock_actual", "stock_minimo", "unidad_medida" },
                values: new object[] { 1, "Inventario inicial del sistema", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Inventario General", 0, 0, "kg" });

            migrationBuilder.InsertData(
                table: "MetodosPagos",
                columns: new[] { "IdMetodoPago", "descripcion", "estado", "id_pago", "nombre" },
                values: new object[] { 1, "Pago en efectivo", true, 1, "Efectivo" });

            migrationBuilder.InsertData(
                table: "Recursos",
                columns: new[] { "id_recurso", "cantidad_recibida", "costo_recurso", "estado", "fecha_ingreso", "id_proveedor", "tipo_recurso", "unidad_medida" },
                values: new object[] { 1, 0, 0f, true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "General", "kg" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Contrasena", "CorreoElectronico", "Estado", "IdRol", "NombreUsuario", "RolIdRol" },
                values: new object[,]
                {
                    { 1, "Admin123", "admin@agronomia.com", true, 1, "admin", null },
                    { 2, "Trab123", "trabajador@agronomia.com", true, 2, "trabajador", null }
                });

            migrationBuilder.InsertData(
                table: "RecursosAdministradores",
                columns: new[] { "id_recursos_administrador", "cantidad_recibida", "estado", "fecha_recepcion", "id_recurso", "observaciones" },
                values: new object[] { 1, 0, true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Registro inicial" });

            migrationBuilder.InsertData(
                table: "Administraciones",
                columns: new[] { "IdAdministracion", "descripcion", "estado", "fecha_registro", "id_inventario", "id_metodo_pago", "id_recursos_administrador", "id_reporte", "id_trabajador", "nombre", "responsable" },
                values: new object[] { 1, "Registro inicial del sistema", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 1, 1, "Administración General", "Sistema" });

            migrationBuilder.CreateIndex(
                name: "IX_Administraciones_id_inventario",
                table: "Administraciones",
                column: "id_inventario");

            migrationBuilder.CreateIndex(
                name: "IX_Administraciones_id_metodo_pago",
                table: "Administraciones",
                column: "id_metodo_pago");

            migrationBuilder.CreateIndex(
                name: "IX_Administraciones_id_recursos_administrador",
                table: "Administraciones",
                column: "id_recursos_administrador");

            migrationBuilder.CreateIndex(
                name: "IX_Administraciones_id_reporte",
                table: "Administraciones",
                column: "id_reporte");

            migrationBuilder.CreateIndex(
                name: "IX_Administraciones_id_trabajador",
                table: "Administraciones",
                column: "id_trabajador");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_id_producto_final",
                table: "Inventarios",
                column: "id_producto_final");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_id_producto_inicial",
                table: "Inventarios",
                column: "id_producto_inicial");

            migrationBuilder.CreateIndex(
                name: "IX_MetodosPagos_id_pago",
                table: "MetodosPagos",
                column: "id_pago");

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_id_proveedor",
                table: "Recursos",
                column: "id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_RecursosAdministradores_id_recurso",
                table: "RecursosAdministradores",
                column: "id_recurso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolIdRol",
                table: "Usuarios",
                column: "RolIdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administraciones");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "MetodosPagos");

            migrationBuilder.DropTable(
                name: "RecursosAdministradores");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ProductosFinales");

            migrationBuilder.DropTable(
                name: "ProductosIniciales");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Recursos");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
