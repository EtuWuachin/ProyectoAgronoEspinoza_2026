using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAgroEspinosa_2026.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_Inventarios_id_inventario",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_MetodosPagos_id_metodo_pago",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_RecursosAdministradores_id_recursos_administrador",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_Reportes_id_reporte",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_Trabajadores_id_trabajador",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_ProductosFinales_id_producto_final",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_ProductosIniciales_id_producto_inicial",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_MetodosPagos_Pagos_id_pago",
                table: "MetodosPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Proveedores_id_proveedor",
                table: "Recursos");

            migrationBuilder.DropForeignKey(
                name: "FK_RecursosAdministradores_Recursos_id_recurso",
                table: "RecursosAdministradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_U_RoleCC_U_RoleCCIdRol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_U_RoleCCIdRol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_MetodosPagos_id_pago",
                table: "MetodosPagos");

            migrationBuilder.DropColumn(
                name: "U_RoleCCIdRol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "id_pago",
                table: "MetodosPagos");

            migrationBuilder.RenameColumn(
                name: "fecha_contrato",
                table: "Trabajadores",
                newName: "fechacontrato");

            migrationBuilder.RenameColumn(
                name: "id_trabajador",
                table: "Trabajadores",
                newName: "idTrabajador");

            migrationBuilder.RenameColumn(
                name: "tipo_reporte",
                table: "Reportes",
                newName: "tiporeporte");

            migrationBuilder.RenameColumn(
                name: "generado_por",
                table: "Reportes",
                newName: "generadopor");

            migrationBuilder.RenameColumn(
                name: "fecha_generacion",
                table: "Reportes",
                newName: "fechageneracion");

            migrationBuilder.RenameColumn(
                name: "id_reporte",
                table: "Reportes",
                newName: "idReporte");

            migrationBuilder.RenameColumn(
                name: "id_recurso",
                table: "RecursosAdministradores",
                newName: "idRecurso");

            migrationBuilder.RenameColumn(
                name: "fecha_recepcion",
                table: "RecursosAdministradores",
                newName: "fecharecepcion");

            migrationBuilder.RenameColumn(
                name: "cantidad_recibida",
                table: "RecursosAdministradores",
                newName: "cantidadrecibida");

            migrationBuilder.RenameColumn(
                name: "id_recursos_administrador",
                table: "RecursosAdministradores",
                newName: "idRecursosAdministrador");

            migrationBuilder.RenameIndex(
                name: "IX_RecursosAdministradores_id_recurso",
                table: "RecursosAdministradores",
                newName: "IX_RecursosAdministradores_idRecurso");

            migrationBuilder.RenameColumn(
                name: "unidad_medida",
                table: "Recursos",
                newName: "unidadmedida");

            migrationBuilder.RenameColumn(
                name: "tipo_recurso",
                table: "Recursos",
                newName: "tiporecurso");

            migrationBuilder.RenameColumn(
                name: "id_proveedor",
                table: "Recursos",
                newName: "idProveedor");

            migrationBuilder.RenameColumn(
                name: "fecha_ingreso",
                table: "Recursos",
                newName: "fechaingreso");

            migrationBuilder.RenameColumn(
                name: "costo_recurso",
                table: "Recursos",
                newName: "costorecurso");

            migrationBuilder.RenameColumn(
                name: "cantidad_recibida",
                table: "Recursos",
                newName: "cantidadrecibida");

            migrationBuilder.RenameColumn(
                name: "id_recurso",
                table: "Recursos",
                newName: "idRecurso");

            migrationBuilder.RenameIndex(
                name: "IX_Recursos_id_proveedor",
                table: "Recursos",
                newName: "IX_Recursos_idProveedor");

            migrationBuilder.RenameColumn(
                name: "id_proveedor",
                table: "Proveedores",
                newName: "idProveedor");

            migrationBuilder.RenameColumn(
                name: "unidad_medida",
                table: "ProductosIniciales",
                newName: "unidadmedida");

            migrationBuilder.RenameColumn(
                name: "proveedor_origen",
                table: "ProductosIniciales",
                newName: "proveedororigen");

            migrationBuilder.RenameColumn(
                name: "fecha_ingreso",
                table: "ProductosIniciales",
                newName: "fechaingreso");

            migrationBuilder.RenameColumn(
                name: "costo_unitario",
                table: "ProductosIniciales",
                newName: "costounitario");

            migrationBuilder.RenameColumn(
                name: "cantidad_inicial",
                table: "ProductosIniciales",
                newName: "cantidadinicial");

            migrationBuilder.RenameColumn(
                name: "id_producto_inicial",
                table: "ProductosIniciales",
                newName: "idProductoInicial");

            migrationBuilder.RenameColumn(
                name: "unidad_medida",
                table: "ProductosFinales",
                newName: "unidadmedida");

            migrationBuilder.RenameColumn(
                name: "precio_venta",
                table: "ProductosFinales",
                newName: "precioventa");

            migrationBuilder.RenameColumn(
                name: "cantidad_producida",
                table: "ProductosFinales",
                newName: "cantidadproducida");

            migrationBuilder.RenameColumn(
                name: "id_producto_final",
                table: "ProductosFinales",
                newName: "idProductoFinal");

            migrationBuilder.RenameColumn(
                name: "fecha_pago",
                table: "Pagos",
                newName: "fechapago");

            migrationBuilder.RenameColumn(
                name: "unidad_medida",
                table: "Inventarios",
                newName: "unidadmedida");

            migrationBuilder.RenameColumn(
                name: "stock_minimo",
                table: "Inventarios",
                newName: "stockminimo");

            migrationBuilder.RenameColumn(
                name: "stock_actual",
                table: "Inventarios",
                newName: "stockactual");

            migrationBuilder.RenameColumn(
                name: "id_producto_inicial",
                table: "Inventarios",
                newName: "idProductoInicial");

            migrationBuilder.RenameColumn(
                name: "id_producto_final",
                table: "Inventarios",
                newName: "idProductoFinal");

            migrationBuilder.RenameColumn(
                name: "fecha_actualizacion",
                table: "Inventarios",
                newName: "fechaactualizacion");

            migrationBuilder.RenameColumn(
                name: "id_iventario",
                table: "Inventarios",
                newName: "idInventario");

            migrationBuilder.RenameIndex(
                name: "IX_Inventarios_id_producto_inicial",
                table: "Inventarios",
                newName: "IX_Inventarios_idProductoInicial");

            migrationBuilder.RenameIndex(
                name: "IX_Inventarios_id_producto_final",
                table: "Inventarios",
                newName: "IX_Inventarios_idProductoFinal");

            migrationBuilder.RenameColumn(
                name: "id_trabajador",
                table: "Administraciones",
                newName: "idTrabajador");

            migrationBuilder.RenameColumn(
                name: "id_reporte",
                table: "Administraciones",
                newName: "idReporte");

            migrationBuilder.RenameColumn(
                name: "id_recursos_administrador",
                table: "Administraciones",
                newName: "idRecursosAdministrador");

            migrationBuilder.RenameColumn(
                name: "id_metodo_pago",
                table: "Administraciones",
                newName: "idInventario");

            migrationBuilder.RenameColumn(
                name: "id_inventario",
                table: "Administraciones",
                newName: "IdPago");

            migrationBuilder.RenameColumn(
                name: "fecha_registro",
                table: "Administraciones",
                newName: "fecharegistro");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_id_trabajador",
                table: "Administraciones",
                newName: "IX_Administraciones_idTrabajador");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_id_reporte",
                table: "Administraciones",
                newName: "IX_Administraciones_idReporte");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_id_recursos_administrador",
                table: "Administraciones",
                newName: "IX_Administraciones_idRecursosAdministrador");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_id_metodo_pago",
                table: "Administraciones",
                newName: "IX_Administraciones_idInventario");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_id_inventario",
                table: "Administraciones",
                newName: "IX_Administraciones_IdPago");

            migrationBuilder.AddColumn<int>(
                name: "IdMetodoPago",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Pagos",
                keyColumn: "IdPago",
                keyValue: 1,
                column: "IdMetodoPago",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdMetodoPago",
                table: "Pagos",
                column: "IdMetodoPago");

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_Inventarios_idInventario",
                table: "Administraciones",
                column: "idInventario",
                principalTable: "Inventarios",
                principalColumn: "idInventario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_Pagos_IdPago",
                table: "Administraciones",
                column: "IdPago",
                principalTable: "Pagos",
                principalColumn: "IdPago",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_RecursosAdministradores_idRecursosAdministrador",
                table: "Administraciones",
                column: "idRecursosAdministrador",
                principalTable: "RecursosAdministradores",
                principalColumn: "idRecursosAdministrador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_Reportes_idReporte",
                table: "Administraciones",
                column: "idReporte",
                principalTable: "Reportes",
                principalColumn: "idReporte",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_Trabajadores_idTrabajador",
                table: "Administraciones",
                column: "idTrabajador",
                principalTable: "Trabajadores",
                principalColumn: "idTrabajador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_ProductosFinales_idProductoFinal",
                table: "Inventarios",
                column: "idProductoFinal",
                principalTable: "ProductosFinales",
                principalColumn: "idProductoFinal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_ProductosIniciales_idProductoInicial",
                table: "Inventarios",
                column: "idProductoInicial",
                principalTable: "ProductosIniciales",
                principalColumn: "idProductoInicial",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_MetodosPagos_IdMetodoPago",
                table: "Pagos",
                column: "IdMetodoPago",
                principalTable: "MetodosPagos",
                principalColumn: "IdMetodoPago",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Proveedores_idProveedor",
                table: "Recursos",
                column: "idProveedor",
                principalTable: "Proveedores",
                principalColumn: "idProveedor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecursosAdministradores_Recursos_idRecurso",
                table: "RecursosAdministradores",
                column: "idRecurso",
                principalTable: "Recursos",
                principalColumn: "idRecurso",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_Inventarios_idInventario",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_Pagos_IdPago",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_RecursosAdministradores_idRecursosAdministrador",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_Reportes_idReporte",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Administraciones_Trabajadores_idTrabajador",
                table: "Administraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_ProductosFinales_idProductoFinal",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_ProductosIniciales_idProductoInicial",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_MetodosPagos_IdMetodoPago",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Proveedores_idProveedor",
                table: "Recursos");

            migrationBuilder.DropForeignKey(
                name: "FK_RecursosAdministradores_Recursos_idRecurso",
                table: "RecursosAdministradores");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_IdMetodoPago",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "IdMetodoPago",
                table: "Pagos");

            migrationBuilder.RenameColumn(
                name: "fechacontrato",
                table: "Trabajadores",
                newName: "fecha_contrato");

            migrationBuilder.RenameColumn(
                name: "idTrabajador",
                table: "Trabajadores",
                newName: "id_trabajador");

            migrationBuilder.RenameColumn(
                name: "tiporeporte",
                table: "Reportes",
                newName: "tipo_reporte");

            migrationBuilder.RenameColumn(
                name: "generadopor",
                table: "Reportes",
                newName: "generado_por");

            migrationBuilder.RenameColumn(
                name: "fechageneracion",
                table: "Reportes",
                newName: "fecha_generacion");

            migrationBuilder.RenameColumn(
                name: "idReporte",
                table: "Reportes",
                newName: "id_reporte");

            migrationBuilder.RenameColumn(
                name: "idRecurso",
                table: "RecursosAdministradores",
                newName: "id_recurso");

            migrationBuilder.RenameColumn(
                name: "fecharecepcion",
                table: "RecursosAdministradores",
                newName: "fecha_recepcion");

            migrationBuilder.RenameColumn(
                name: "cantidadrecibida",
                table: "RecursosAdministradores",
                newName: "cantidad_recibida");

            migrationBuilder.RenameColumn(
                name: "idRecursosAdministrador",
                table: "RecursosAdministradores",
                newName: "id_recursos_administrador");

            migrationBuilder.RenameIndex(
                name: "IX_RecursosAdministradores_idRecurso",
                table: "RecursosAdministradores",
                newName: "IX_RecursosAdministradores_id_recurso");

            migrationBuilder.RenameColumn(
                name: "unidadmedida",
                table: "Recursos",
                newName: "unidad_medida");

            migrationBuilder.RenameColumn(
                name: "tiporecurso",
                table: "Recursos",
                newName: "tipo_recurso");

            migrationBuilder.RenameColumn(
                name: "idProveedor",
                table: "Recursos",
                newName: "id_proveedor");

            migrationBuilder.RenameColumn(
                name: "fechaingreso",
                table: "Recursos",
                newName: "fecha_ingreso");

            migrationBuilder.RenameColumn(
                name: "costorecurso",
                table: "Recursos",
                newName: "costo_recurso");

            migrationBuilder.RenameColumn(
                name: "cantidadrecibida",
                table: "Recursos",
                newName: "cantidad_recibida");

            migrationBuilder.RenameColumn(
                name: "idRecurso",
                table: "Recursos",
                newName: "id_recurso");

            migrationBuilder.RenameIndex(
                name: "IX_Recursos_idProveedor",
                table: "Recursos",
                newName: "IX_Recursos_id_proveedor");

            migrationBuilder.RenameColumn(
                name: "idProveedor",
                table: "Proveedores",
                newName: "id_proveedor");

            migrationBuilder.RenameColumn(
                name: "unidadmedida",
                table: "ProductosIniciales",
                newName: "unidad_medida");

            migrationBuilder.RenameColumn(
                name: "proveedororigen",
                table: "ProductosIniciales",
                newName: "proveedor_origen");

            migrationBuilder.RenameColumn(
                name: "fechaingreso",
                table: "ProductosIniciales",
                newName: "fecha_ingreso");

            migrationBuilder.RenameColumn(
                name: "costounitario",
                table: "ProductosIniciales",
                newName: "costo_unitario");

            migrationBuilder.RenameColumn(
                name: "cantidadinicial",
                table: "ProductosIniciales",
                newName: "cantidad_inicial");

            migrationBuilder.RenameColumn(
                name: "idProductoInicial",
                table: "ProductosIniciales",
                newName: "id_producto_inicial");

            migrationBuilder.RenameColumn(
                name: "unidadmedida",
                table: "ProductosFinales",
                newName: "unidad_medida");

            migrationBuilder.RenameColumn(
                name: "precioventa",
                table: "ProductosFinales",
                newName: "precio_venta");

            migrationBuilder.RenameColumn(
                name: "cantidadproducida",
                table: "ProductosFinales",
                newName: "cantidad_producida");

            migrationBuilder.RenameColumn(
                name: "idProductoFinal",
                table: "ProductosFinales",
                newName: "id_producto_final");

            migrationBuilder.RenameColumn(
                name: "fechapago",
                table: "Pagos",
                newName: "fecha_pago");

            migrationBuilder.RenameColumn(
                name: "unidadmedida",
                table: "Inventarios",
                newName: "unidad_medida");

            migrationBuilder.RenameColumn(
                name: "stockminimo",
                table: "Inventarios",
                newName: "stock_minimo");

            migrationBuilder.RenameColumn(
                name: "stockactual",
                table: "Inventarios",
                newName: "stock_actual");

            migrationBuilder.RenameColumn(
                name: "idProductoInicial",
                table: "Inventarios",
                newName: "id_producto_inicial");

            migrationBuilder.RenameColumn(
                name: "idProductoFinal",
                table: "Inventarios",
                newName: "id_producto_final");

            migrationBuilder.RenameColumn(
                name: "fechaactualizacion",
                table: "Inventarios",
                newName: "fecha_actualizacion");

            migrationBuilder.RenameColumn(
                name: "idInventario",
                table: "Inventarios",
                newName: "id_iventario");

            migrationBuilder.RenameIndex(
                name: "IX_Inventarios_idProductoInicial",
                table: "Inventarios",
                newName: "IX_Inventarios_id_producto_inicial");

            migrationBuilder.RenameIndex(
                name: "IX_Inventarios_idProductoFinal",
                table: "Inventarios",
                newName: "IX_Inventarios_id_producto_final");

            migrationBuilder.RenameColumn(
                name: "idTrabajador",
                table: "Administraciones",
                newName: "id_trabajador");

            migrationBuilder.RenameColumn(
                name: "idReporte",
                table: "Administraciones",
                newName: "id_reporte");

            migrationBuilder.RenameColumn(
                name: "idRecursosAdministrador",
                table: "Administraciones",
                newName: "id_recursos_administrador");

            migrationBuilder.RenameColumn(
                name: "idInventario",
                table: "Administraciones",
                newName: "id_metodo_pago");

            migrationBuilder.RenameColumn(
                name: "fecharegistro",
                table: "Administraciones",
                newName: "fecha_registro");

            migrationBuilder.RenameColumn(
                name: "IdPago",
                table: "Administraciones",
                newName: "id_inventario");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_idTrabajador",
                table: "Administraciones",
                newName: "IX_Administraciones_id_trabajador");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_idReporte",
                table: "Administraciones",
                newName: "IX_Administraciones_id_reporte");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_idRecursosAdministrador",
                table: "Administraciones",
                newName: "IX_Administraciones_id_recursos_administrador");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_IdPago",
                table: "Administraciones",
                newName: "IX_Administraciones_id_inventario");

            migrationBuilder.RenameIndex(
                name: "IX_Administraciones_idInventario",
                table: "Administraciones",
                newName: "IX_Administraciones_id_metodo_pago");

            migrationBuilder.AddColumn<int>(
                name: "U_RoleCCIdRol",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_pago",
                table: "MetodosPagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MetodosPagos",
                keyColumn: "IdMetodoPago",
                keyValue: 1,
                column: "id_pago",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "U_RoleCCIdRol",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "U_RoleCCIdRol",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_U_RoleCCIdRol",
                table: "Usuarios",
                column: "U_RoleCCIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_MetodosPagos_id_pago",
                table: "MetodosPagos",
                column: "id_pago");

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_Inventarios_id_inventario",
                table: "Administraciones",
                column: "id_inventario",
                principalTable: "Inventarios",
                principalColumn: "id_iventario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_MetodosPagos_id_metodo_pago",
                table: "Administraciones",
                column: "id_metodo_pago",
                principalTable: "MetodosPagos",
                principalColumn: "IdMetodoPago",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_RecursosAdministradores_id_recursos_administrador",
                table: "Administraciones",
                column: "id_recursos_administrador",
                principalTable: "RecursosAdministradores",
                principalColumn: "id_recursos_administrador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_Reportes_id_reporte",
                table: "Administraciones",
                column: "id_reporte",
                principalTable: "Reportes",
                principalColumn: "id_reporte",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Administraciones_Trabajadores_id_trabajador",
                table: "Administraciones",
                column: "id_trabajador",
                principalTable: "Trabajadores",
                principalColumn: "id_trabajador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_ProductosFinales_id_producto_final",
                table: "Inventarios",
                column: "id_producto_final",
                principalTable: "ProductosFinales",
                principalColumn: "id_producto_final",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_ProductosIniciales_id_producto_inicial",
                table: "Inventarios",
                column: "id_producto_inicial",
                principalTable: "ProductosIniciales",
                principalColumn: "id_producto_inicial",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MetodosPagos_Pagos_id_pago",
                table: "MetodosPagos",
                column: "id_pago",
                principalTable: "Pagos",
                principalColumn: "IdPago",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Proveedores_id_proveedor",
                table: "Recursos",
                column: "id_proveedor",
                principalTable: "Proveedores",
                principalColumn: "id_proveedor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecursosAdministradores_Recursos_id_recurso",
                table: "RecursosAdministradores",
                column: "id_recurso",
                principalTable: "Recursos",
                principalColumn: "id_recurso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_U_RoleCC_U_RoleCCIdRol",
                table: "Usuarios",
                column: "U_RoleCCIdRol",
                principalTable: "U_RoleCC",
                principalColumn: "IdRol");
        }
    }
}
