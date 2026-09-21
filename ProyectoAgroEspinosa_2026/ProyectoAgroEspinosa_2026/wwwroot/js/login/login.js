document.addEventListener('DOMContentLoaded', function () {

    const togglePw = document.getElementById('togglePw');
    const inputPassword = document.getElementById('inputPassword');

    togglePw.addEventListener('click', function () {
        if (inputPassword.type === 'password') {
            inputPassword.type = 'text';
            togglePw.textContent = 'visibility_off';
        } else {
            inputPassword.type = 'password';
            togglePw.textContent = 'visibility';
        }
    });

    const form = document.getElementById('formLogin');
    const inputCorreo = document.getElementById('inputCorreo');
    const errorCorreo = document.getElementById('errorCorreo');

    // Regex: exige al menos 2 caracteres antes del @, dominio válido y termina en 2-8 letras (evita "a@8.com" o "_@8.com")
    const CORREO_REGEX = /^[a-zA-Z0-9](?:[a-zA-Z0-9._%+-]{1,63})@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.[a-zA-Z]{2,8}$/;

    function validarCorreo() {
        const valor = inputCorreo.value.trim();
        const grupo = inputCorreo.closest('.input-group-custom');

        if (valor === '') {
            marcarError(grupo, errorCorreo, 'El correo es obligatorio.');
            return false;
        }
        if (valor.length > 100) {
            marcarError(grupo, errorCorreo, 'El correo no puede superar los 100 caracteres.');
            return false;
        }
        if (!CORREO_REGEX.test(valor)) {
            marcarError(grupo, errorCorreo, 'Ingrese un correo válido (ej: nombre@dominio.com).');
            return false;
        }

        limpiarError(grupo, errorCorreo);
        return true;
    }

    function marcarError(grupo, spanError, mensaje) {
        grupo.classList.add('input-invalid');
        spanError.textContent = mensaje;
    }

    function limpiarError(grupo, spanError) {
        grupo.classList.remove('input-invalid');
        spanError.textContent = '';
    }

    inputCorreo.addEventListener('blur', validarCorreo);
    inputCorreo.addEventListener('input', function () {
        if (inputCorreo.closest('.input-group-custom').classList.contains('input-invalid')) {
            validarCorreo();
        }
    });

    form.addEventListener('submit', function (e) {
        const correoValido = validarCorreo();
        if (!correoValido) {
            e.preventDefault();
            inputCorreo.focus();
        }
    });

});