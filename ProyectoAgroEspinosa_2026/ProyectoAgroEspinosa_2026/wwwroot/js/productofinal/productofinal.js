document.addEventListener('DOMContentLoaded', function () {

    const formProductoFinal = document.getElementById('formProductoFinal');

    if (formProductoFinal) {

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
        const inputNombre = formProductoFinal.querySelector('[name="nombre"]');
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
        const inputDescripcion = formProductoFinal.querySelector('[name="descripcion"]');
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

        // ── Cantidad producida: entero positivo con tope ──
        const inputCantidad = formProductoFinal.querySelector('[name="cantidad_producida"]');
        const CANTIDAD_MIN = 1;
        const CANTIDAD_MAX = 100000;

        function validarCantidad() {
            const errorSpan = obtenerGrupoError(inputCantidad);
            const valor = inputCantidad.value.trim();
            if (valor === '') {
                inputCantidad.classList.add('input-invalid');
                errorSpan.textContent = 'La cantidad producida es obligatoria.';
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
        const inputUnidad = formProductoFinal.querySelector('[name="unidad_medida"]');
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

        // ── Precio de venta ──
        const inputPrecio = formProductoFinal.querySelector('[name="precio_venta"]');
        const PRECIO_MIN = 0.01;
        const PRECIO_MAX = 1000000;

        function validarPrecio() {
            const errorSpan = obtenerGrupoError(inputPrecio);
            const valor = inputPrecio.value.trim();
            if (valor === '') {
                inputPrecio.classList.add('input-invalid');
                errorSpan.textContent = 'El precio de venta es obligatorio.';
                return false;
            }
            const numero = Number(valor);
            if (isNaN(numero) || numero < PRECIO_MIN || numero > PRECIO_MAX) {
                inputPrecio.classList.add('input-invalid');
                errorSpan.textContent = `Debe ser un monto entre S/. ${PRECIO_MIN} y S/. ${PRECIO_MAX.toLocaleString('es-PE')}.`;
                return false;
            }
            inputPrecio.classList.remove('input-invalid');
            errorSpan.textContent = '';
            return true;
        }

        // Listeners
        const camposTexto = [
            { input: inputNombre, validar: validarNombre },
            { input: inputDescripcion, validar: validarDescripcion },
            { input: inputCantidad, validar: validarCantidad },
            { input: inputUnidad, validar: validarUnidad },
            { input: inputPrecio, validar: validarPrecio }
        ];

        camposTexto.forEach(function (campo) {
            if (!campo.input) return;
            campo.input.addEventListener('blur', campo.validar);
            campo.input.addEventListener('input', function () {
                if (campo.input.classList.contains('input-invalid')) campo.validar();
            });
        });

        formProductoFinal.addEventListener('submit', function (e) {
            let esValido = true;

            if (!validarNombre()) esValido = false;
            if (!validarDescripcion()) esValido = false;
            if (!validarCantidad()) esValido = false;
            if (!validarUnidad()) esValido = false;
            if (!validarPrecio()) esValido = false;

            if (!esValido) {
                e.preventDefault();
                const primerError = formProductoFinal.querySelector('.input-invalid');
                if (primerError) primerError.focus();
            }
        });
    }

    // ── Función de Ordenamiento (misma lógica usada en administracion.js) ──
    function habilitarOrdenamiento(tabla, filas, alOrdenar) {
        const tbody = tabla.querySelector('tbody');
        const headers = tabla.querySelectorAll('th[data-type]');
        let columnaActual = null;
        let ascendente = true;

        headers.forEach(function (th) {
            th.classList.add('th-sortable');
            th.addEventListener('click', function () {
                const tipo = th.dataset.type;
                const indice = Array.from(th.parentElement.children).indexOf(th);

                if (columnaActual === indice) {
                    ascendente = !ascendente;
                } else {
                    columnaActual = indice;
                    ascendente = true;
                }

                headers.forEach(function (h) {
                    const icono = h.querySelector('.sort-icon');
                    if (icono) icono.textContent = 'unfold_more';
                    h.classList.remove('th-activo');
                });

                const iconoActivo = th.querySelector('.sort-icon');
                if (iconoActivo) iconoActivo.textContent = ascendente ? 'arrow_upward' : 'arrow_downward';
                th.classList.add('th-activo');

                filas.sort(function (a, b) {
                    const celdaA = a.children[indice];
                    const celdaB = b.children[indice];

                    const valorA = celdaA.dataset.sortValue !== undefined ? celdaA.dataset.sortValue : celdaA.textContent.trim();
                    const valorB = celdaB.dataset.sortValue !== undefined ? celdaB.dataset.sortValue : celdaB.textContent.trim();

                    let resultado;
                    if (tipo === 'number') {
                        resultado = parseFloat(valorA) - parseFloat(valorB);
                    } else if (tipo === 'date') {
                        resultado = new Date(valorA) - new Date(valorB);
                    } else {
                        resultado = valorA.localeCompare(valorB, 'es', { sensitivity: 'base' });
                    }

                    return ascendente ? resultado : -resultado;
                });

                filas.forEach(function (fila) { tbody.appendChild(fila); });

                alOrdenar();
            });
        });
    }

    const tabla = document.getElementById('tablaProductosFinales');

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

        habilitarOrdenamiento(tabla, todasLasFilas, function () {
            paginaActual = 1;
            renderTabla();
        });

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

function confirmarEliminarProductoFinal() {
    return confirm("¿Está seguro que desea eliminar este producto?");
}