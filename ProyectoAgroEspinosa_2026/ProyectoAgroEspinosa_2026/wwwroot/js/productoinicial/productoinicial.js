document.addEventListener('DOMContentLoaded', function () {

    const formProductoInicial = document.getElementById('formProductoInicial');

    if (formProductoInicial) {

        function obtenerGrupoError(input) {
            let errorSpan = input.parentElement.querySelector('.field-error');
            if (!errorSpan) {
                errorSpan = document.createElement('span');
                errorSpan.className = 'field-error';
                input.parentElement.appendChild(errorSpan);
            }
            return errorSpan;
        }

        // ── Nombre: identificador, NO lleva @ ──
        const inputNombre = formProductoInicial.querySelector('[name="nombre"]');
        const NOMBRE_REGEX = /^(?=.*[a-zA-ZÀ-ÿ])[a-zA-ZÀ-ÿ0-9.,\-\s]{3,100}$/;

        function validarNombre() {
            const errorSpan = obtenerGrupoError(inputNombre);
            const valor = inputNombre.value.trim();
            if (valor === '') {
                inputNombre.classList.add('input-invalid');
                errorSpan.textContent = 'El nombre es obligatorio.';
                return false;
            }
            if (!NOMBRE_REGEX.test(valor)) {
                inputNombre.classList.add('input-invalid');
                errorSpan.textContent = 'Debe contener letras, sin símbolos como @, entre 3 y 100 caracteres.';
                return false;
            }
            inputNombre.classList.remove('input-invalid');
            errorSpan.textContent = '';
            return true;
        }

        // ── Descripción: texto libre, SÍ permite @ ──
        const inputDescripcion = formProductoInicial.querySelector('[name="descripcion"]');
        const DESCRIPCION_REGEX = /^(?=.*[a-zA-ZÀ-ÿ])[a-zA-ZÀ-ÿ0-9.,°@\-\s]{5,250}$/;

        function validarDescripcion() {
            const errorSpan = obtenerGrupoError(inputDescripcion);
            const valor = inputDescripcion.value.trim();
            if (valor === '') {
                inputDescripcion.classList.add('input-invalid');
                errorSpan.textContent = 'La descripción es obligatoria.';
                return false;
            }
            if (!DESCRIPCION_REGEX.test(valor)) {
                inputDescripcion.classList.add('input-invalid');
                errorSpan.textContent = 'Debe contener letras, entre 5 y 250 caracteres.';
                return false;
            }
            inputDescripcion.classList.remove('input-invalid');
            errorSpan.textContent = '';
            return true;
        }

        // ── Cantidad inicial: entero positivo con tope ──
        const inputCantidad = formProductoInicial.querySelector('[name="cantidad_inicial"]');
        const CANTIDAD_MIN = 1;
        const CANTIDAD_MAX = 100000;

        function validarCantidad() {
            const errorSpan = obtenerGrupoError(inputCantidad);
            const valor = inputCantidad.value.trim();
            if (valor === '') {
                inputCantidad.classList.add('input-invalid');
                errorSpan.textContent = 'La cantidad inicial es obligatoria.';
                return false;
            }
            const numero = Number(valor);
            if (!Number.isInteger(numero) || numero < CANTIDAD_MIN || numero > CANTIDAD_MAX) {
                inputCantidad.classList.add('input-invalid');
                errorSpan.textContent = `Debe ser un entero entre ${CANTIDAD_MIN} y ${CANTIDAD_MAX}.`;
                return false;
            }
            inputCantidad.classList.remove('input-invalid');
            errorSpan.textContent = '';
            return true;
        }

        // ── Unidad de medida: solo letras ──
        const inputUnidad = formProductoInicial.querySelector('[name="unidad_medida"]');
        const UNIDAD_REGEX = /^[a-zA-ZÀ-ÿ.\s]{1,20}$/;

        function validarUnidad() {
            const errorSpan = obtenerGrupoError(inputUnidad);
            const valor = inputUnidad.value.trim();
            if (valor === '') {
                inputUnidad.classList.add('input-invalid');
                errorSpan.textContent = 'La unidad de medida es obligatoria.';
                return false;
            }
            if (!UNIDAD_REGEX.test(valor)) {
                inputUnidad.classList.add('input-invalid');
                errorSpan.textContent = 'Solo letras (ej. kg, L, unidades), máx. 20 caracteres.';
                return false;
            }
            inputUnidad.classList.remove('input-invalid');
            errorSpan.textContent = '';
            return true;
        }

        // ── Costo unitario ──
        const inputCosto = formProductoInicial.querySelector('[name="costo_unitario"]');
        const COSTO_MIN = 0.01;
        const COSTO_MAX = 1000000;

        function validarCosto() {
            const errorSpan = obtenerGrupoError(inputCosto);
            const valor = inputCosto.value.trim();
            if (valor === '') {
                inputCosto.classList.add('input-invalid');
                errorSpan.textContent = 'El costo unitario es obligatorio.';
                return false;
            }
            const numero = Number(valor);
            if (isNaN(numero) || numero < COSTO_MIN || numero > COSTO_MAX) {
                inputCosto.classList.add('input-invalid');
                errorSpan.textContent = `Debe ser un monto entre S/. ${COSTO_MIN} y S/. ${COSTO_MAX.toLocaleString('es-PE')}.`;
                return false;
            }
            inputCosto.classList.remove('input-invalid');
            errorSpan.textContent = '';
            return true;
        }

        // ── Fecha de ingreso: obligatoria, no futura ──
        const inputFecha = formProductoInicial.querySelector('[name="fecha_ingreso"]');

        function validarFecha() {
            const errorSpan = obtenerGrupoError(inputFecha);
            if (!inputFecha.value) {
                inputFecha.classList.add('input-invalid');
                errorSpan.textContent = 'Seleccione una fecha.';
                return false;
            }
            const fechaSeleccionada = new Date(inputFecha.value);
            const hoy = new Date();
            hoy.setHours(0, 0, 0, 0);
            if (fechaSeleccionada > hoy) {
                inputFecha.classList.add('input-invalid');
                errorSpan.textContent = 'La fecha de ingreso no puede ser futura.';
                return false;
            }
            inputFecha.classList.remove('input-invalid');
            errorSpan.textContent = '';
            return true;
        }

        // ── Proveedor origen: identificador, NO lleva @ ──
        const inputProveedorOrigen = formProductoInicial.querySelector('[name="proveedor_origen"]');
        const PROVEEDOR_ORIGEN_REGEX = /^(?=.*[a-zA-ZÀ-ÿ])[a-zA-ZÀ-ÿ0-9.,\-\s]{3,100}$/;

        function validarProveedorOrigen() {
            const errorSpan = obtenerGrupoError(inputProveedorOrigen);
            const valor = inputProveedorOrigen.value.trim();
            if (valor === '') {
                inputProveedorOrigen.classList.add('input-invalid');
                errorSpan.textContent = 'El proveedor origen es obligatorio.';
                return false;
            }
            if (!PROVEEDOR_ORIGEN_REGEX.test(valor)) {
                inputProveedorOrigen.classList.add('input-invalid');
                errorSpan.textContent = 'Debe contener letras, sin símbolos como @, entre 3 y 100 caracteres.';
                return false;
            }
            inputProveedorOrigen.classList.remove('input-invalid');
            errorSpan.textContent = '';
            return true;
        }

        // Listeners
        const camposTexto = [
            { input: inputNombre, validar: validarNombre },
            { input: inputDescripcion, validar: validarDescripcion },
            { input: inputCantidad, validar: validarCantidad },
            { input: inputUnidad, validar: validarUnidad },
            { input: inputCosto, validar: validarCosto },
            { input: inputProveedorOrigen, validar: validarProveedorOrigen }
        ];

        camposTexto.forEach(function (campo) {
            if (!campo.input) return;
            campo.input.addEventListener('blur', campo.validar);
            campo.input.addEventListener('input', function () {
                if (campo.input.classList.contains('input-invalid')) campo.validar();
            });
        });

        if (inputFecha) inputFecha.addEventListener('change', validarFecha);

        formProductoInicial.addEventListener('submit', function (e) {
            let esValido = true;

            if (!validarNombre()) esValido = false;
            if (!validarDescripcion()) esValido = false;
            if (!validarCantidad()) esValido = false;
            if (!validarUnidad()) esValido = false;
            if (!validarCosto()) esValido = false;
            if (!validarFecha()) esValido = false;
            if (!validarProveedorOrigen()) esValido = false;

            if (!esValido) {
                e.preventDefault();
                const primerError = formProductoInicial.querySelector('.input-invalid');
                if (primerError) primerError.focus();
            }
        });
    }

    const tabla = document.getElementById('tablaProductosIniciales');

    if (tabla) {
        const tbody = tabla.querySelector('tbody');
        const todasLasFilas = Array.from(tbody.querySelectorAll('tr')).filter(f => !f.querySelector('.no-data'));

        const buscador = document.getElementById('buscador');
        const selectTamano = document.getElementById('tamanoPagina');
        const btnAnterior = document.getElementById('btnPagAnterior');
        const btnSiguiente = document.getElementById('btnPagSiguiente');
        const infoLabel = document.getElementById('paginadorInfo');
        const paginaLabel = document.getElementById('paginadorPagina');

        let paginaActual = 1;
        let tamanoPagina = parseInt(selectTamano.value, 10);

        function filasFiltradas() {
            const filtro = buscador.value.toLowerCase().trim();
            if (!filtro) return todasLasFilas;
            return todasLasFilas.filter(fila => fila.textContent.toLowerCase().includes(filtro));
        }

        function renderTabla() {
            const filas = filasFiltradas();
            const totalFilas = filas.length;
            const totalPaginas = Math.max(1, Math.ceil(totalFilas / tamanoPagina));

            if (paginaActual > totalPaginas) paginaActual = totalPaginas;
            if (paginaActual < 1) paginaActual = 1;

            todasLasFilas.forEach(f => f.style.display = 'none');

            if (totalFilas === 0) {
                infoLabel.textContent = 'Sin resultados';
                paginaLabel.textContent = '0 de 0';
                btnAnterior.disabled = true;
                btnSiguiente.disabled = true;
                return;
            }

            const inicio = (paginaActual - 1) * tamanoPagina;
            const fin = Math.min(inicio + tamanoPagina, totalFilas);

            for (let i = inicio; i < fin; i++) {
                filas[i].style.display = '';
            }

            infoLabel.textContent = `${inicio + 1}–${fin} de ${totalFilas}`;
            paginaLabel.textContent = `Página ${paginaActual} de ${totalPaginas}`;

            btnAnterior.disabled = paginaActual === 1;
            btnSiguiente.disabled = paginaActual === totalPaginas;
        }

        buscador.addEventListener('keyup', function () {
            paginaActual = 1;
            renderTabla();
        });

        selectTamano.addEventListener('change', function () {
            tamanoPagina = parseInt(this.value, 10);
            paginaActual = 1;
            renderTabla();
        });

        btnAnterior.addEventListener('click', function () {
            paginaActual--;
            renderTabla();
        });

        btnSiguiente.addEventListener('click', function () {
            paginaActual++;
            renderTabla();
        });

        renderTabla();
    }

});

function confirmarEliminarProductoInicial() {
    return confirm("¿Está seguro que desea eliminar este producto?");
}